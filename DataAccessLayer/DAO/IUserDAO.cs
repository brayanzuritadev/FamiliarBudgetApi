using FamiliarBudgetApi.BLL.DTOs;
using FamiliarBudgetApi.DAL.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FamiliarBudgetApi.DAL.DAO
{
    public interface IUserDAO{
        public List<UserDTO> GetAll(string family);
        public bool Insert(User user);
        public bool Update(User user);
        public bool Delete(User user);
        public bool GetBack(User user);
    }
}
