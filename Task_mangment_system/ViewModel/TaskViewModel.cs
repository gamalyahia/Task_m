using System.ComponentModel.DataAnnotations;
using Task_mangment_system.Models;

namespace Task_mangment_system.ViewModel
{
    public class TaskViewModel
    {
        public string Title { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        [MaxLength(100)]

        public string Status { get; set; }
        public string Priority { get; set; }
        public DateTime Deadline { get; set; }

        public int ProjectID { get; set; }
        public List<Project> projects { get; set; }
        public int TeamMemberID { get; set; }
        public List<TeamMember> teamMembers { get; set; }
    }
}
