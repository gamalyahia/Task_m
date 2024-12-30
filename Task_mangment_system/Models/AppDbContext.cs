using Microsoft.EntityFrameworkCore;
using Task_mangment_system.ViewModel;

namespace Task_mangment_system.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<task>()
            //    .HasOne(x => x.teamMember)
            //    .WithMany(x => x.Tasks)
            //    .HasForeignKey(x => x.TaskID)
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<task>()
            //    .HasOne(x => x.Project)
            //    .WithMany(x => x.Tasks)
            //    .HasForeignKey(x => x.TaskID)
            //    .OnDelete(DeleteBehavior.Cascade);


            //modelBuilder.Entity<TeamMember>()
            //    .HasMany(x => x.Tasks)
            //    .WithOne(x => x.teamMember)
            //    .HasForeignKey(x => x.TeamMemberId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Project>()
            //    .HasMany(x => x.Tasks)
            //    .WithOne(x => x.Project)
            //    .HasForeignKey(x => x.ProjectID)
            //    .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TaskViewModel>().HasNoKey();

        }


        public DbSet<TeamMember> teamMembers { get; set; }
        public DbSet<task> Tasks { get; set; }
        public DbSet<Project> Projects { get; set; }


    }
}