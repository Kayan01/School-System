using AutoMapper;
using SchoolSystem.Models;
using SchoolSystem.Models.DTOs.StudentDto;
using SchoolSystem.Models.DTOs.UserDto;

namespace SchoolSystem.Mapper
{
    public class StudentConfiguration : Profile
    {
        public StudentConfiguration()
        {
                CreateMap<CreateStudentDto, Student>().ReverseMap();
                CreateMap<Student, StudentDto>().ReverseMap();
                CreateMap<CreateCourseDto, Course>().ReverseMap();
                CreateMap<Course, CourseDto>().ReverseMap();    
        }
    }
}
