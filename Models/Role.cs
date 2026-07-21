using System.ComponentModel.DataAnnotations;

namespace demo.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [Required,MaxLength(50)]
        public string RoleName { get; set; } = string.Empty;

        [MaxLength(250)]
        public string Description { get; set; } = string.Empty;
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

    }
}
