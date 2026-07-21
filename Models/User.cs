using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace demo.Models
{
    
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [ForeignKey("UserTypeId")]
        public int UserTypeId { get; set; }
        public UserType? UserType { get; set; }

        [Required,MaxLength(150)]
        public string FullName { get; set; }

        [MaxLength(100)]
        public string UserCode { get; set; }

        [EmailAddress]
        [Required,MaxLength(150)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [MaxLength(10)]
        public string MobileNumber { get; set; }

        [Required,MaxLength(500)]
        public string ProfilePicturePath { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public bool? IsDeleted { get; set; }
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
        public ICollection<ProjectAllocation> StudentProjects { get; set; } = new List<ProjectAllocation>();
        public ICollection<ProjectAllocation> FacultyProjects { get; set; } = new List<ProjectAllocation>();

    }
}
