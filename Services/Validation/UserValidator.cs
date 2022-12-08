using FamiliarBudgetApi.Data.DataAccess;
using FamiliarBudgetApi.Data.DTOs;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace FamiliarBudgetApi.Services.Validation
{
    public class UserValidator : IValidator<UserDTO>
    {
        private readonly IFamilyDAO familyDao;
        private readonly IUserDAO userDao;
        public UserValidator(IFamilyDAO familyDao, IUserDAO userDao)
        {
            this.familyDao = familyDao;
            this.userDao = userDao;
        }
        public bool Validate(UserDTO validationObject)
        {
            var family = familyDao.GetFamily(validationObject.FamilyCode);

            //verificamos que el rol este dentro de lo requerido
            if (validationObject.RoleId == 2 && family == null)
            {
                return false;
            }

            if (validationObject.RoleId < 1 || validationObject.RoleId > 2)
            {
                return false;
            }

            //verificamos que el email no este registrado dentro de la base de datos
            var exist = userDao.SearchByEmail(validationObject.Email);
            if (exist)
            {
                return false;
            }    

            return true;
        }

    }
}
