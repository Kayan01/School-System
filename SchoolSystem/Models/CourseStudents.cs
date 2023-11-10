namespace SchoolSystem.Models
{
    public class CourseStudents
    {     public Guid StudentId { get; set; }
        public Student Students { get; set; }
        public Guid CourseId { get; set; }
        public Course  Courses   { get; set; }
    }
}
