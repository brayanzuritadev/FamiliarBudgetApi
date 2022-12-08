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
        public bool Update(User user);
        public bool Delete(User user);
        public bool SearchByEmail(string email);
    }
}
