
using FamiliarBudgetApi.Data.Models;

namespace FamiliarBudgetApi.Services
{
    public interface ILoginService
    {
        public User GetCurrentUser();
        public string Login(User userLogin);
    }
}
