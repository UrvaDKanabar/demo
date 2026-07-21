using System.ComponentModel.DataAnnotations;
namespace demo.Models
{
    public class ProjectMaster
    {
        [Key] public int ProjectId { get; set; }

        [Required,MaxLength(200)] public string ProjectTitle { get; set; } = string.Empty;

        public string? Description { get; set; }
        public ICollection<ProjectAllocation> ProjectAllocations { get; set; } = new List<ProjectAllocation>();
    }
}