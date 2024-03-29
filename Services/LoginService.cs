﻿
using FamiliarBudgetApi.Data.DataAccess;
using FamiliarBudgetApi.Data.Models;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using FamiliarBudgetApi.Data.DTOs;

namespace FamiliarBudgetApi.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginDAO loginDb;
        private readonly IConfiguration configuration;
        private readonly IHttpContextAccessor contextAccessor;

        public LoginService(ILoginDAO loginDb, IConfiguration configuration, IHttpContextAccessor contextAccessor)
        {
            this.loginDb = loginDb;
            this.configuration = configuration;
            this.contextAccessor = contextAccessor;
        }

        public string Login(UserDTO userLogin)
        {
            var user = loginDb.GetByEmailAndPassword(userLogin);

            if (user != null)
            {
                return GenerateJwtToken(user);
            }
            return null;
        }

        private string GenerateJwtToken(UserDTO user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["jwt:key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("ID",user.ID.ToString()),
                new Claim("FamilyCode",user.FamilyCode.ToString()),
                new Claim("FamilyId",user.FamilyId.ToString()),
                new Claim(ClaimTypes.Role,user.RoleId.ToString())
            };

            var token = new JwtSecurityToken(
                configuration["jwt:issuer"],
                configuration["jwt:audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public UserDTO GetCurrentUser()
        {
            var current = contextAccessor.HttpContext.User.Identity as ClaimsIdentity;

            var user = new UserDTO
            {
                FamilyCode = current.Claims.FirstOrDefault(x => x.Type == "FamilyCode").Value,
                RoleId = Int32.Parse(current.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value),
                FamilyId = Int32.Parse(current.Claims.FirstOrDefault(x => x.Type == "FamilyId").Value),
            };
            return user;
        }
    }
}
