using System.ComponentModel.DataAnnotations;
namespace demo.Models
{
    public class ProjectTaskStatus
    {
        [Key] public int TaskStatusId { get; set; }

        [Required,MaxLength(20)]
        public string TaskStatusName { get; set; } = string.Empty;

        [Required, MaxLength(100)]
        public string TaskStatusCssClass { get; set; } = string.Empty;

        public ICollection<ProjectTask> Tasks { get; set; } = new List<ProjectTask>();
    }
}
