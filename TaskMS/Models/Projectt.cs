using System.ComponentModel.DataAnnotations;

namespace TaskMS.Models
{
    public class Projectt
    {
        [Key]
        public int ProjectId { get; set; }
        [MaxLength(100)]
        public string ProjectName { get; set; }
        [MaxLength (500)]
        public string ProjectDescription { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ICollection<tTask> tasks { get; set; }
    }
}
