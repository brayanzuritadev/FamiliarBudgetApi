
using FamiliarBudgetApi.BLL.DTOs;
using FamiliarBudgetApi.DAL.DAO;
using FamiliarBudgetApi.DAL.Models;
using FamiliarBudgetApi.DataAccessLayer.DAO;

namespace FamiliarBudgetApi.BusinessLogicalLayer.Validation
{
    public class UserValidator : IValidator<UserDTO>
    {
        private readonly IFamilyDAO familyDao;
        private readonly IUserDAO userDao;
        public UserValidator(IFamilyDAO familyDAO)
        {
            this.familyDao = familyDAO;
        }
        public bool Validate(UserDTO validationObject)
        {
            var family = familyDao.GetFamily(validationObject.FamilyCode);

            if (validationObject.RoleId == 2 && family == null)
            {
                return false;
            }

            if (validationObject.RoleId < 1 || validationObject.RoleId > 2)
            {
                return false;
            }

            return true;
        }
    }
}
