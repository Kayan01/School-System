using SchoolSystem.Models;
using SchoolSystem.Models.DTOs.StudentDto;
using SchoolSystem.Models.DTOs.UserDto;
using SchoolSystem.ResponseClass;

namespace SchoolSystem.Contracts
{
    public interface ICourseService
    {
        Task<SuccessResponse<CourseDto>> CourseRegistration(CreateCourseDto model);
        Task<SuccessResponse<List<StudentDto>>> GetStudentsForCourse(Guid courseId);
    }
}
