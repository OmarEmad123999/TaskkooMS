using System.ComponentModel.DataAnnotations;

namespace TaskMS.Models
{
    public class TeamMember
    {
        [Key]
        public int MemberId {  get; set; }
        [MaxLength(100)]
        public string MemberName { get; set; }
        [MaxLength (100)]
        public string MemberEmail {  get; set; }
        [MaxLength(50)]
        public string MemberRole { get; set; }

        public ICollection<tTask> tasks { get; set; }
    }
}
