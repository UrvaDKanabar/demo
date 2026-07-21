using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace demo.Models
{
    public class ProjectTask
    {
        [Key] public int TaskId { get; set; }

        [Required, MaxLength(200)] public string TaskTitle { get; set; } = string.Empty;

        public string? TaskDescription { get; set; }

        [ForeignKey("ProjectAllocationId")]
        public int ProjectAllocationId { get; set; }
        public ProjectAllocation? ProjectAllocation { get; set; }

        [Required,ForeignKey("TaskStatusId")]
        public int TaskStatusId {  get; set; }
        public ProjectTaskStatus? TaskStatus { get; set; }

        [Required,ForeignKey("TaskPriorityId")]
        public int TaskPriorityId { get; set; }
        public TaskPriority? TaskPriority { get; set; }

        [Required]
        public float AssignedScore { get; set; }


        public float EarnedScore { get; set; }


        [Required]
        public float ProgressPercentage{ get; set; }
        public DateTime TaskAssignedDate { get; set; }
        public DateTime TaskStartDate { get; set; }
        public DateTime TaskDueDate { get; set; }
        public DateTime TaskCompletedDate { get; set; }
        public DateTime CompletedDate { get; set; }
        public DateTime NextFollowUpDate { get; set; }
        public string FacultyRemarks { get; set; }= string.Empty;

        [MaxLength(500)]
        public string?  StudentRemarks {  get; set; }





    }
}
