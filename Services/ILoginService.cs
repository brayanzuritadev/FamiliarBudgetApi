
using FamiliarBudgetApi.Data.DTOs;
using FamiliarBudgetApi.Data.Models;

namespace FamiliarBudgetApi.Services
{
    public interface ILoginService
    {
        public UserDTO GetCurrentUser();
        public string Login(UserDTO userLogin);
    }
}
