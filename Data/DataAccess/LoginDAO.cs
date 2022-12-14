using FamiliarBudgetApi.Data.DTOs;
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

        public UserDTO GetByEmailAndPassword(UserDTO userLogin)
        {
            UserDTO userDto = new UserDTO();
            var userDba = (from u in context.User.Where(x => x.Email == userLogin.Email && x.Password==userLogin.Password)
                           join f in context.Family on u.FamilyId equals f.ID
                           join r in context.Role on u.RoleId equals r.ID
                           select new
                           {
                               userId = u.ID,
                               firstName = u.FirstName,
                               lastName = u.LastName,
                               email = u.Email,
                               role = r.RoleName,
                               familyCode = f.FamilyCode,
                               familyId = f.ID,
                               roleId = r.ID
                           }).ToList();

            if (userDba.Count != 0)
            {
                var user = userDba.FirstOrDefault();
                userDto.ID = user.userId;
                userDto.FirstName = user.firstName;
                userDto.LastName = user.lastName;
                userDto.Email = user.email;
                userDto.RoleId = user.roleId;
                userDto.RoleName = user.role;
                userDto.FamilyId = user.familyId;
                userDto.FamilyCode = user.familyCode;
                return userDto;
            }
            return null;
        }
    }
}
