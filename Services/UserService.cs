using FamiliarBudgetApi.Data.DataAccess;
using FamiliarBudgetApi.Data.DTOs;
using FamiliarBudgetApi.Data.Models;
using FamiliarBudgetApi.Services.Validation;

namespace FamiliarBudgetApi.Services
{
    public class UserService : IUserService
    {
        private readonly IValidation validation;
        private readonly ILoginService loginService;
        private readonly IUserDAO userDao;
        private readonly IFamilyDAO familyDao;

        public UserService(IUserDAO userDao, IFamilyDAO familyDao, IValidation Validation, ILoginService loginService)
        {
            this.userDao = userDao;
            this.familyDao = familyDao;
            this.validation = Validation;
            this.loginService = loginService;
        }

        public bool Delete(int id)
        {
            return GetUserById(id) == null || !userDao.Delete(id) ? false : true;

            /*
            if (GetUserById(id) == null || !userDao.Delete(id))
            {
                return false;
            }

            return true;
            */
        }

        public List<UserDTO> GetAll()
        {
            var currentUser = loginService.GetCurrentUser();

            var user = userDao.GetAll(currentUser.FamilyId);

            return user;
            
        }

        public UserDTO GetUserById(int id)
        {
            return userDao.GetUserById(id);
        }

        public string Insert(UserDTO userDTO)
        {
            User user = new User();

            if (!validation.Validate(userDTO))
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

            // TODO: Move this session initializacion to the controller
            if (userDao.Insert(user))
            {
                var token = loginService.Login(userDTO);
                return token;
            }
            else
            {
                return null;
            }
        }

        public bool UpdateUser(UserDTO userDto)
        {
            var family = validation.ValidateFamilyCode(userDto.FamilyCode);
            var role = validation.ValidateRole(userDto.RoleId);

            if (family == null || role == false || GetUserById(userDto.ID) == null)
            {
                return false;
            }
            
            userDto.FamilyId = family.ID;

            return userDao.UpdateUser(userDto);
        }
    }
}
