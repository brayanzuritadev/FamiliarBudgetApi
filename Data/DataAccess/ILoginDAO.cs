using FamiliarBudgetApi.Data.Models;

namespace FamiliarBudgetApi.Data.DataAccess
{
    public interface ILoginDAO
    {
        public User GetByEmailAndPassword(User userLogin);
    }
}
