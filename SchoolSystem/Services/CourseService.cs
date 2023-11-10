using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Contracts;
using SchoolSystem.Data;
using SchoolSystem.Helpers;
using SchoolSystem.Models.DTOs.StudentDto;
using SchoolSystem.Models;
using SchoolSystem.ResponseClass;
using System.Net;
using SchoolSystem.Models.DTOs.UserDto;

namespace SchoolSystem.Services
{
    public class CourseService : ICourseService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        public CourseService(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        //public async Task<SuccessResponse<CourseDto>> CourseRegistration(CreateCourseDto model)
        //{
        //    var course = await _applicationDbContext.Courses.FirstOrDefaultAsync(x => x.CourseName == model.CourseName & x.CourseCode == model.CourseCode & x.StudentId == model.StudentId);
        //    if (course is not null)
        //    {
        //        throw new RestException(HttpStatusCode.Conflict, "Student already registered for this course", "studentId");
        //    }
        //    var newCourse = _mapper.Map<Course>(model);
        //    await _applicationDbContext.Courses.AddAsync(newCourse);
        //    await _applicationDbContext.SaveChangesAsync();
        //    var user = _mapper.Map<CourseDto>(newCourse);
        //    return new SuccessResponse<CourseDto>()
        //    {
        //        Data = user,
        //        Message = "Course Created for student"

        //    };
        //}
        public async Task<SuccessResponse<CourseDto>> CourseRegistration(CreateCourseDto model)
        {
            var studentId = model.StudentId;

            Course course = null;

            // Check if the course already exists
            course = await _applicationDbContext.Courses
                .FirstOrDefaultAsync(c => c.CourseCode == model.CourseCode);

            if (course == null)
            {
                // If the course doesn't exist, create it and retrieve the generated CourseId
                var newCourse = _mapper.Map<Course>(model);
                await _applicationDbContext.Courses.AddAsync(newCourse);
                await _applicationDbContext.SaveChangesAsync();
                course = newCourse;
            }

            // Create a new CourseStudents entry
            var newCourseStudent = new CourseStudents
            {
                StudentId = studentId,
                CourseId = course.Id
            };

            // Add the new entry to the CourseStudents table
            await _applicationDbContext.CourseStudent.AddAsync(newCourseStudent);
            await _applicationDbContext.SaveChangesAsync();

            // Map course to CourseDto
            var user = _mapper.Map<CourseDto>(course);

            return new SuccessResponse<CourseDto>
            {
                Data = user,
                Message = "Course Created for student"
            };
        }


        public async Task<SuccessResponse<List<StudentDto>>> GetStudentsForCourse(Guid courseId)
        {
            var courseStudents = await _applicationDbContext.CourseStudent.ToListAsync();

            if (courseStudents == null || courseStudents.Count == 0)
            {
                return new SuccessResponse<List<StudentDto>>
                {
                    Data = new List<StudentDto>(),
                    Message = "No course registrations found"
                };
            }

            var studentsForCourse = courseStudents
                .Where(cs => cs.CourseId == courseId)
                .Select(cs => cs.Students)
                .ToList();

            var studentDtos = _mapper.Map<List<StudentDto>>(studentsForCourse);

            if (studentDtos.Count == 0)
            {
                return new SuccessResponse<List<StudentDto>>
                {
                    Data = new List<StudentDto>(),
                    Message = "No students found for the specified course"
                };
            }

            return new SuccessResponse<List<StudentDto>>
            {
                Data = studentDtos,
                Message = "Students found for the specified course"
            };
        }

    }

}
