using System.ComponentModel.DataAnnotations;
namespace demo.Models
{
    public class UserType
    {
        [Key] public int UserTypeId { get; set; }

        [Required, MaxLength(50)]
        public string UserTypeName { get; set; } = string.Empty;

        [MaxLength(250)]
        public string Description { get; set; }= string.Empty;

        public ICollection<User>? Users { get; set; }
    }
}
