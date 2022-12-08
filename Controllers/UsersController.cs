using FamiliarBudgetApi.Data.DTOs;
using FamiliarBudgetApi.Data.Models;
using FamiliarBudgetApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using System.Security.Claims;

namespace FamiliarBudgetApi.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly ILoginService lservice;

        public UsersController(IUserService userService)
        {

            this.userService = userService;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Authorize(Roles = ("1"))]
        public ActionResult<User> GetAll()
        {
            var users =userService.GetAll();

            return Ok(users);
        }

        [HttpPost]
        public ActionResult<AuthenticationResponse> Post(UserDTO user)
        {
            
            var tokenUserCreate = userService.Insert(user);
            if (tokenUserCreate == null)
            {
                return BadRequest("Could not create user");
            };
            
            return Ok(new { response = tokenUserCreate });
        }
    }
}
