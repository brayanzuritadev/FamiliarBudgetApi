using FamiliarBudgetApi.Data.DTOs;
using FamiliarBudgetApi.Data.Models;

namespace FamiliarBudgetApi.Services
{
    public interface IUserService
    {
        public List<UserDTO> GetAll();
        public string Insert(UserDTO user);
        public bool UpdateUser(UserDTO user);
        public bool Delete(int id);
        public UserDTO GetUserById(int id);
    }
}
