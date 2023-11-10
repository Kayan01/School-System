namespace SchoolSystem.Models
{
    public class Course
    {
        public Guid Id { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public Guid StudentId { get; set; }
        //public ICollection<Student> Students { get; set; }

        public List<CourseStudents> CourseStudents { get; set; }
    }
}
