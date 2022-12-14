using FamiliarBudgetApi.Data.DTOs;
using FamiliarBudgetApi.Data.Models;

namespace FamiliarBudgetApi.Services.Validation
{
    public interface IValidation { 
        public bool Validate(UserDTO validatonObject);
        public Family ValidateFamilyCode(string familyCode);
        public bool ValidateRole(int roleId);
        public bool ValidateUser(int userId);
    }
}
