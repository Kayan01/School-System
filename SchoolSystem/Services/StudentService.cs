using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Contracts;
using SchoolSystem.Data;
using SchoolSystem.Helpers;
using SchoolSystem.Models;
using SchoolSystem.Models.DTOs.StudentDto;
using SchoolSystem.ResponseClass;
using System.Net;

namespace SchoolSystem.Services
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        public StudentService(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        public async Task<SuccessResponse<StudentDto>> CreateStudent(CreateStudentDto model)
        {
            var student = await _applicationDbContext.Students.FirstOrDefaultAsync(x => x.Email == model.Email);
            if (student is not null)
            {
                throw new RestException(HttpStatusCode.Conflict, "Student already exist", "studentId");
            }
            var newStudent = _mapper.Map<Student>(model);
            await _applicationDbContext.Students.AddAsync(newStudent);
            await _applicationDbContext.SaveChangesAsync();
            var user = _mapper.Map<StudentDto>(newStudent);
            return new SuccessResponse<StudentDto>()
            {
                Data = user,
                Message = "User Created"

            };

        }
        public async Task<SuccessResponse<StudentDto>> GetStudentById(Guid studentId)
        {
            var student = await _applicationDbContext.Students.FirstOrDefaultAsync(x => x.Id == studentId);
            if (student is null)
            {
                throw new RestException(HttpStatusCode.NotFound, "Student does not exist", "studentId");
            }
            var user = _mapper.Map<StudentDto>(student);

            return new SuccessResponse<StudentDto>()
            {
                Data = user,
                Message = "student found"

            };

        }
        public async Task<SuccessResponse<List<StudentDto>>> GetAllStudents()
        {
            var students = await _applicationDbContext.Students.ToListAsync();
            var agbaDtos = _mapper.Map<List<StudentDto>>(students);

            if (agbaDtos.Count == 0)
            {
                return new SuccessResponse<List<StudentDto>>()
                {
                    Data = new List<StudentDto>(), // Empty list
                    Message = "No students found"
                };
            }

            return new SuccessResponse<List<StudentDto>>()
            {
                Data = agbaDtos,
                Message = "Students found"
            };
        }


        public async Task<SuccessResponse<StudentDto>> DeleteStudentById(Guid studentId)
        {
            var student = await _applicationDbContext.Students.FirstOrDefaultAsync(x => x.Id == studentId);
            if (student is null)
            {
                throw new RestException(HttpStatusCode.NotFound, "Student does not exist", "studentId");
            }
             _applicationDbContext.Remove(student);
            await _applicationDbContext.SaveChangesAsync();

            var agbaDto = _mapper.Map<StudentDto>(student);

            return new SuccessResponse<StudentDto>
            {
                Data = agbaDto,
                Message = "Student deleted"
            };

        }
        public async Task<SuccessResponse<StudentDto>> UpdateStudentById(Guid studentId, UpdateStudentDto updateModel)
        {
            var student = await _applicationDbContext.Students.FirstOrDefaultAsync(x => x.Id == studentId);

            if (student is null)
            {
                throw new RestException(HttpStatusCode.NotFound, "Student does not exist", "studentId");
            }

            // You can update the properties of the 'student' entity with values from 'updateModel'.
            // For example, assuming 'Name' is an updatable property:
            student.Name = updateModel.Name;
            student.Email = updateModel.Email;
            student.DateOfBirth = updateModel.DateOfBirth;
            // Save the changes to the database
            await _applicationDbContext.SaveChangesAsync();

            var agbaDto = _mapper.Map<StudentDto>(student);

            return new SuccessResponse<StudentDto>
            {
                Data = agbaDto,
                Message = "Student updated"
            };
        }


    }
}
