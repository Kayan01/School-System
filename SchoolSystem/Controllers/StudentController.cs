using Microsoft.AspNetCore.Mvc;
using SchoolSystem.Contracts;
using SchoolSystem.Models.DTOs.StudentDto;
using SchoolSystem.ResponseClass;
using SchoolSystem.Services;

namespace SchoolSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }



        [HttpPost]
        [Route("[action]")]
        public async Task<SuccessResponse<StudentDto>> CreateStudent(CreateStudentDto model)
        {
            var result = await _studentService.CreateStudent(model);
            return result;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<SuccessResponse<StudentDto>> GetStudentById(Guid studentId)
        {
            var result = await _studentService.GetStudentById(studentId);
            return result;
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<SuccessResponse<StudentDto>> DeleteStudentById(Guid studentId)
        {
            var result = await _studentService.DeleteStudentById(studentId);
            return result;
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<SuccessResponse<List<StudentDto>>> GetAllStudents()
        {
            var result = await _studentService.GetAllStudents();
            return result;
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<SuccessResponse<StudentDto>> UpdateStudentById(Guid studentId, UpdateStudentDto updateModel)
        {
            var result = await _studentService.UpdateStudentById(studentId, updateModel);
            return result;
        }

    }
}