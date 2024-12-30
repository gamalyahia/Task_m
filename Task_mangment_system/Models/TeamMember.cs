using System.ComponentModel.DataAnnotations;

namespace Task_mangment_system.Models
{
    public class TeamMember
    {
        [Key]
        public int TeamMemberId { get; set; }
        [MaxLength(100)]

        public string Name { get; set; }
        [MaxLength(100)]

        public string Email { get; set; }
        [MaxLength(50)]

        public string Role { get; set; }

        public ICollection<task> Tasks { get; set; }


    }
}