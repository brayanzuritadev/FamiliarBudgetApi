using FamiliarBudgetApi.Data.DataAccess;
using FamiliarBudgetApi.Data.DTOs;
using FamiliarBudgetApi.Data.Models;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace FamiliarBudgetApi.Services.Validation
{
    public class Validation : IValidation
    {
        private readonly IFamilyDAO familyDao;
        private readonly IUserDAO userDao;
        public Validation(IFamilyDAO familyDao, IUserDAO userDao)
        {
            this.familyDao = familyDao;
            this.userDao = userDao;
        }
        public bool Validate(UserDTO validationObject)
        {
            var family = ValidateFamilyCode(validationObject.FamilyCode);

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
            var exist = userDao.SearchUserByEmail(validationObject.Email);
            if (exist)
            {
                return false;
            }    

            return true;
        }

        public Family ValidateFamilyCode(string familyCode)
        {
            return familyDao.GetFamily(familyCode);
        }

        public bool ValidateRole(int roleId)
        {
            if (roleId>2||roleId<0)
            {
                return false;
            }
            return true;
        }

        public bool ValidateUser(int userId) {

            if (userDao.GetUserById(userId) == null)
            {
                return false;
            }

            return true;
        }
    }
}
