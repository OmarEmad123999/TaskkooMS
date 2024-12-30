using System.ComponentModel.DataAnnotations;

namespace TaskMS.Models
{
    public class tTask
    {
        [Key]
        public int TaskID { get; set; }
        [MaxLength(100)]
        public string TaskTitle { get; set; }
        [MaxLength(500)]
        public string TaskDescription {  get; set; }

        public string TaskStatus {  get; set; }
        public string TaskPriority { get; set; }

        public DateTime DeadLine { get; set; }

        public int ProjectId {  get; set; }
        public Projectt projectt { get; set; }
        public int TeamMemberId {  get; set; }
        public TeamMember teamMember { get; set; }
    }
}
