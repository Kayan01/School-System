namespace SchoolSystem.Models.DTOs.UserDto
{
    public class CourseDto
    {

        public string Name { get; set; }
        public string CourseCode { get; set; }
        public string CourseTitle { get; set; }
        public Guid  StudentId { get; set; }

    }
    public record CreateCourseDto
    {
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public string CourseTitle{ get; set; }
        public Guid StudentId { get; set; }

    }
    public record GetStudentDto
    { 
        public Guid CourseId { get; set; }
    }
}
