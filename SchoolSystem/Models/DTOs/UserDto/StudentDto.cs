using Microsoft.VisualBasic;

namespace SchoolSystem.Models.DTOs.StudentDto
{
    public record StudentDto
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set;}
        public string Email { get; set; }
    }
    public record CreateStudentDto
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }

    }
    public record UpdateStudentDto : CreateStudentDto
    {
        public Guid StudentId { get; set; }
    }
 
}
