using Microsoft.AspNetCore.Mvc;
using SchoolSystem.Contracts;
using SchoolSystem.Models;
using SchoolSystem.Models.DTOs.StudentDto;
using SchoolSystem.Models.DTOs.UserDto;
using SchoolSystem.ResponseClass;

namespace SchoolSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController : ControllerBase
    {

        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }



        [HttpPost]
        [Route("[action]")]
        public async Task<SuccessResponse<CourseDto>> CourseRegistration(CreateCourseDto model)
        {
            var result = await _courseService.CourseRegistration(model);
            return result;
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<SuccessResponse<List<StudentDto>>> GetStudentsForCourse(Guid courseId)
        {
            var result = await _courseService.GetStudentsForCourse(courseId);
            return result;
        }

    }
}
