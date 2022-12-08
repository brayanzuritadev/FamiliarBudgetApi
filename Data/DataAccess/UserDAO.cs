using FamiliarBudgetApi.Data.DTOs;
using FamiliarBudgetApi.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace FamiliarBudgetApi.Data.DataAccess
{
    public class UserDAO : IUserDAO
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<IdentityUser> userManager;

        public UserDAO(ApplicationDbContext context,
                        UserManager<IdentityUser> userManager
                        )
        {
            this.context = context;
            this.userManager = userManager;
        }

        public bool Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public List<UserDTO> GetAll(int familyId)
        {

            List<UserDTO> users = new List<UserDTO>();
            var list = (from u in context.User.Where(x => x.FamilyId ==  familyId)
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
                        }).OrderBy(x => x.firstName).ToList();
            foreach (var item in list)
            {
                UserDTO dto = new UserDTO();
                dto.ID = item.userId;
                dto.FirstName = item.firstName;
                dto.LastName = item.lastName;
                dto.Email = item.email;
                dto.RoleName = item.role;
                dto.FamilyId = item.familyId;
                dto.RoleId = item.roleId;
                dto.FamilyCode = item.familyCode;
                users.Add(dto);
            }
            return users;
        }

        public bool SearchByEmail(string email)
        {
            var exist = context.User.Any(x=>x.Email==email);
            if (exist)
            {
                return true;
            }
            return false;
        }
        public bool Insert(User entity)
        {

            try
            {
                context.User.Add(entity);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
