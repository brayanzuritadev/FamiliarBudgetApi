using FamiliarBudgetApi.BLL.DTOs;
using FamiliarBudgetApi.DAL.Models;
using FamiliarBudgetApi.DataAccessLayer.ContextDB;

namespace FamiliarBudgetApi.DAL.DAO
{
    public class UserDAO : IUserDAO
    {
        private readonly ApplicationDbContext context;

        public UserDAO(ApplicationDbContext context)
        {
            this.context = context;
        }

        public bool Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public List<UserDTO> GetAll(string familyCode)
        {
            List<UserDTO> users = new List<UserDTO>();
            var list = (from f in context.Family.Where(x => x.FamilyCode == familyCode)
                        join u in context.User on  f.ID equals u.FamilyId
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

        public bool GetBack(User entity)
        {
            throw new NotImplementedException();
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
