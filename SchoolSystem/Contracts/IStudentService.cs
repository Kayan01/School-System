using SchoolSystem.Models.DTOs.StudentDto;
using SchoolSystem.ResponseClass;

namespace SchoolSystem.Contracts
{
    public interface IStudentService
    {
        Task<SuccessResponse<StudentDto>> CreateStudent(CreateStudentDto model);
        Task<SuccessResponse<StudentDto>> GetStudentById(Guid studentId);
        Task<SuccessResponse<StudentDto>> DeleteStudentById(Guid studentId);
        Task<SuccessResponse<List<StudentDto>>> GetAllStudents();
        Task<SuccessResponse<StudentDto>> UpdateStudentById(Guid studentId, UpdateStudentDto updateModel);
    }
}
