using FamiliarBudgetApi.Data.DTOs;
using FamiliarBudgetApi.Data.Models;

namespace FamiliarBudgetApi.Services.Validation
{
    public interface IUserValidator{ 
        public bool Validate(UserDTO validationObject);
    }
}
