using System.ComponentModel.DataAnnotations;

namespace Task_mangment_system.Models
{
    public class Project
    {
        [Key]
        public int ProjectID { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(500)]

        public string Description { get; set; }


        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ICollection<task> Tasks { get; set; }

    }
}
