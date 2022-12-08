using FamiliarBudgetApi.Data.DataAccess;
using FamiliarBudgetApi.Data.DTOs;
using FamiliarBudgetApi.Data.Models;
using FamiliarBudgetApi.Services.Validation;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FamiliarBudgetApi.Services
{
    public class UserService : IUserService
    {
        private readonly IValidator<UserDTO> userValidator;
        private readonly ILoginService loginService;
        private readonly IUserDAO userDao;
        private readonly IFamilyDAO familyDao;

        public UserService(IUserDAO userDao, IFamilyDAO familyDao, IValidator<UserDTO> UserValidator, ILoginService loginService)
        {
            this.userDao = userDao;
            this.familyDao = familyDao;
            this.userValidator = UserValidator;
            this.loginService = loginService;
        }


        public bool Delete(User user)
        {
            throw new NotImplementedException();
        }

        public List<UserDTO> GetAll()
        {
            var currentUser = loginService.GetCurrentUser();

            var user = userDao.GetAll(currentUser.FamilyId);

            return user;
            
        }

        public string Insert(UserDTO userDTO)
        {

            User user = new User();

            if (!userValidator.Validate(userDTO))
            {
                return null;
            }

            if (userDTO.RoleId == 1)
            {
                Family family = new Family();
                Guid g = Guid.NewGuid();
                family.FamilyCode = g.ToString();
                familyDao.InsertFamily(family);
                userDTO.FamilyCode = g.ToString();
            }

            user.FirstName = userDTO.FirstName;
            user.LastName = userDTO.LastName;
            user.Email = userDTO.Email;
            user.Password = userDTO.Password;
            user.RoleId = userDTO.RoleId;
            user.FamilyId = familyDao.GetFamily(userDTO.FamilyCode).ID;

            if (userDao.Insert(user))
            {
                var token = loginService.Login(user);
                return token;
            }
            else
            {
                return null;
            }

        }

        
        public bool Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
