using System.ComponentModel.DataAnnotations;

namespace Task_mangment_system.Models
{
    public class task
    {
        [Key]
        public int TaskID { get; set; }
        [MaxLength(100)]

        public string Title { get; set; }
        [MaxLength(500)]

        public string Description { get; set; }

        public string Status { get; set; }
        public string Priority { get; set; }
        public DateTime Deadline { get; set; }

        public int ProjectID { get; set; }
        public Project Project { get; set; }
        public int TeamMemberId { get; set; }
        public TeamMember teamMember { get; set; }
        
    }
}