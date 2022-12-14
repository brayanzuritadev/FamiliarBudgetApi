using FamiliarBudgetApi.Data.DTOs;
using FamiliarBudgetApi.Data.Models;

namespace FamiliarBudgetApi.Data.DataAccess
{
    public interface ILoginDAO
    {
        public UserDTO GetByEmailAndPassword(UserDTO userLogin);
    }
}
