namespace SchoolSystem.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        // public Guid CourseId { get; set; }
        // public Course Courses { get ; set; }     
       // public ICollection<Course> Courses { get; set; }
        public List<CourseStudents> CourseStudents { get; set; }
    }
}
