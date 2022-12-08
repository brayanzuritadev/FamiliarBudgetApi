using FamiliarBudgetApi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FamiliarBudgetApi.Data.DataAccess
{
    public class LoginDAO:ILoginDAO
    {
        private readonly ApplicationDbContext context;
        public LoginDAO(ApplicationDbContext context)
        {
            this.context = context;
        }

        public User GetByEmailAndPassword(User userLogin)
        {
            var user = context.User.FirstOrDefault(x=> x.Email.ToLower()==userLogin.Email.ToLower()
                && x.Password==userLogin.Password);

            if (user != null)
            {
                User userFound = new User();
                userFound.ID = user.ID;
                userFound.RoleId = user.RoleId;
                userFound.FamilyId = user.FamilyId;
                return user;
            }
            return null;
        }
    }
}
