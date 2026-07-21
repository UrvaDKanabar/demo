using System.ComponentModel.DataAnnotations;
namespace demo.Models
{
    public class TaskPriority
    {
        [Key] public int TaskPriorityId { get; set; }

        [Required,MaxLength(20)]
        public string TaskPriorityName { get; set; } = string.Empty;

        [Required,MaxLength(20)]
        public int TaskPriorityCssClass { get; set; }
        public ICollection<ProjectTask> Tasks { get; set; } = new List<ProjectTask>();
    }
}
