using FamiliarBudgetApi.Data.DTOs;
using FamiliarBudgetApi.Data.Models;

namespace FamiliarBudgetApi.Services
{
    public interface IUserService
    {
        public List<UserDTO> GetAll();
        public string Insert(UserDTO user);
        public bool Update(User user);
        public bool Delete(User user);
    }
}
