using demo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace demo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { 
        }
        

        public DbSet<User> user => Set<User>();
        public DbSet<UserRole> userrole => Set<UserRole>() ;

        public DbSet<Role> role => Set<Role>() ;
        public DbSet<UserType> usertype => Set<UserType>() ;
        public DbSet<ProjectTaskStatus> taskstatus => Set<ProjectTaskStatus>() ;
        public DbSet<TaskPriority> taskpriority => Set<TaskPriority>() ;
        public DbSet<ProjectMaster> projectmaster => Set<ProjectMaster>() ;
        public DbSet<ProjectAllocation> projectallocation => Set<ProjectAllocation>() ;
        public DbSet<ProjectTask> task => Set<ProjectTask>() ;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProjectAllocation>()
                .HasOne(p => p.Student)
                .WithMany(u => u.StudentProjects)
                .HasForeignKey(p => p.StudentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ProjectAllocation>()
                .HasOne(p => p.Faculty)
                .WithMany(u => u.FacultyProjects)
                .HasForeignKey(p => p.FacultyId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }

}


