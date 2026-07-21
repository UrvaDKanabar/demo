using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace demo.Models
{
    public class ProjectAllocation
    {
        [Key] public int ProjectAlocationId { get; set; }

        public int ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public ProjectMaster? ProjectMaster { get; set; }

        public int StudentId { get; set; }

        [ForeignKey("StudentId")]
        public User? Student { get; set; }

        public int FacultyId { get; set; }

        [ForeignKey("FacultyId")]
        public User? Faculty { get; set; }

        [Required]
        public DateTime AssignedDate { get; set; } = DateTime.Now;

        [Required]
        public DateTime ProjectStartDate { get; set; }

        [Required]
        public DateTime ProjectEndDate { get; set; }

        [Required]
        public int TotalTasksGiven { get; set; }

        [Required]
        public int TotalCompletedTasks { get; set; }

        [Required]
        public float ProgressPercentage { get; set; }

        public char OverAllGrade { get; set; }
        public ICollection<ProjectTask> Tasks { get; set; } = new List<ProjectTask>();
    }
}
