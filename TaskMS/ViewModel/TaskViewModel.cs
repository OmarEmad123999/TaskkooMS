using System.ComponentModel.DataAnnotations;
using TaskMS.Models;

namespace TaskMS.ViewModel
{
    public class TaskViewModel
    {
        public string title {  get; set; }
        [MaxLength(500)]

        public string description { get; set; }
        [MaxLength (100)]

        public string status { get; set; }
        public string priority { get; set; }
        
        public DateTime DeadLine {  get; set; }
        public int projectid {  get; set; }
        public ICollection<Projectt> projectts { get; set; }
        public int memberid {  get; set; }
        public ICollection<TeamMember> teamMembers { get; set; }
    }
}
