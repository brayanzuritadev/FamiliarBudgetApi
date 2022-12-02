using FamiliarBudgetApi.BLL.DTOs;
using FamiliarBudgetApi.DAL.Models;

namespace FamiliarBudgetApi.BLL
{
    public interface IUserService
    {
        public List<UserDTO> GetAll(string familyCode);
        public UserDTO Insert(UserDTO user);
        public bool Update(User user);
        public bool Delete(User user);
    }
}
