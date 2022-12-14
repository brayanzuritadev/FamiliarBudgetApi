using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FamiliarBudgetApi.Data.DTOs
{
    public class UserDTO
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public int RoleId { get; set; }
        public int FamilyId { get; set; }
        public string RoleName { get; set; }
        public string FamilyCode { get; set; }
    }
}
