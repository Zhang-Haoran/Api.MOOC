using Microsoft.EntityFrameworkCore;

namespace Api.MOOC.Models
{
    public class MoocDbContext: DbContext
    {
        public MoocDbContext(DbContextOptions<MoocDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseSchedule> CourseSchedules { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<TeacherCourse> TeacherCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<Course>()
                .HasIndex(c => c.CategoryId);

            modelBuilder.Entity<CourseSchedule>()
                .HasIndex(cs => cs.CourseId);

            modelBuilder.Entity<Message>()
                .HasIndex(m => m.CourseId);
        }
    }
}
