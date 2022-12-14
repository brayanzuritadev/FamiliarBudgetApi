using FamiliarBudgetApi.Data.DataAccess;
using FamiliarBudgetApi.Data.DTOs;

namespace FamiliarBudgetApi.Services.Validation
{
    public class UserValidator : IUserValidator
    {
        private readonly IFamilyDAO familyDao;
        private readonly IUserDAO userDao;
        public UserValidator(IFamilyDAO familyDao, IUserDAO userDao)
        {
            this.familyDao = familyDao;
            this.userDao = userDao;
        }

        /// <summary>
        /// Checks the user consistency by verifying:
        /// - The user role is correct
        /// - The family code of the user is correct
        /// - The user exists
        /// </summary>
        public bool Validate(UserDTO validationObject)
        {
            if (validationObject.RoleId > 2 || validationObject.RoleId < 0)
            {
                return false;
            }

            if (familyDao.GetFamily(validationObject.FamilyCode) == null)
            {
                return false;
            }

            if (userDao.GetUserById(validationObject.ID) == null)
            {
                return false;
            }

            return true;
        }
    }
}
