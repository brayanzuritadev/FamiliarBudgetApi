using FamiliarBudgetApi.Data.DTOs;
using FamiliarBudgetApi.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FamiliarBudgetApi.Data.DataAccess
{
    public interface IUserDAO
    {
        public List<UserDTO> GetAll(int familtId);
        public bool Insert(User user);
        public bool UpdateUser(UserDTO user);
        public bool Delete(int id);
        public bool SearchUserByEmail(string email);
        public UserDTO GetUserById(int id);
    }
}
