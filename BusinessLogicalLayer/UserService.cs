using FamiliarBudgetApi.BLL.DTOs;
using FamiliarBudgetApi.BusinessLogicalLayer.Validation;
using FamiliarBudgetApi.DAL.DAO;
using FamiliarBudgetApi.DAL.Models;
using FamiliarBudgetApi.DataAccessLayer.DAO;
using Microsoft.IdentityModel.Tokens;

namespace FamiliarBudgetApi.BLL
{
    public class UserService :IUserService
    {
        private readonly IValidator<UserDTO> userValidator;

        private readonly IUserDAO userDao;
        private readonly IFamilyDAO familyDao;

        public UserService(IUserDAO userDao, IFamilyDAO familyDao, IValidator<UserDTO> UserValidator)
        {
            this.userDao = userDao;
            this.familyDao = familyDao;
            this.userValidator = UserValidator;
        }
        

        public bool Delete(User user)
        {
            throw new NotImplementedException();
        }

        public List<UserDTO> GetAll(string familyCode)
        {
            return userDao.GetAll(familyCode);
        }

        public UserDTO Insert(UserDTO userDTO)
        {
            User user = new User();

            if (!userValidator.Validate(userDTO))
            {
                return null;
            }

            if (userDTO.RoleId==1)
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
            user.RoleId= userDTO.RoleId;
            user.FamilyId = familyDao.GetFamily(userDTO.FamilyCode).ID;
            userDao.Insert(user);
            return userDTO;
        }

        public bool Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
