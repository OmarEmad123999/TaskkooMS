using Microsoft.EntityFrameworkCore;

namespace TaskMS.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }

        public DbSet<Projectt> projject {  get; set; }
        public DbSet<tTask> taskk { get; set; }
        public DbSet<TeamMember> teammember { get; set; }
    }
}
