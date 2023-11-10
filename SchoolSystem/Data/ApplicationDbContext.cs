using Microsoft.EntityFrameworkCore;
using SchoolSystem.Models;

namespace SchoolSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options): base(options) 
        {
                
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseStudents> CourseStudent { get;}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseStudents>()
                .HasKey(cs => new { cs.StudentId, cs.CourseId });

            modelBuilder.Entity<CourseStudents>()
                .HasOne(cs => cs.Students)
                .WithMany(s => s.CourseStudents)
                .HasForeignKey(cs => cs.StudentId);

            modelBuilder.Entity<CourseStudents>()
                .HasOne(cs => cs.Courses)
                .WithMany(c => c.CourseStudents)
                .HasForeignKey(cs => cs.CourseId);
        }

    }
}

