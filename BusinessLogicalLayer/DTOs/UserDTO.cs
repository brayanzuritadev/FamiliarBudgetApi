using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FamiliarBudgetApi.BLL.DTOs
{
    public class UserDTO
    {
        public int ID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int RoleId { get; set; }
        public int FamilyId { get; set; }
        [Required]
        public string RoleName { get; set; }
        public string FamilyCode { get; set; }
    }
}
