using kolos2.Data;
using kolos2.Models;
using kolos2.DTOs;
using Microsoft.EntityFrameworkCore;

namespace kolos2.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;
    public DbService(DatabaseContext context) => _context = context;

    public async Task<IEnumerable<Enrollment>> GetEnrollmentsAsync()
    {
        return await _context.Enrollments
            .Include(e => e.Student)
            .Include(e => e.Course)
            .ToListAsync();
    }

    public async Task<CreatedCourseResponseDTO> AddCourseWithEnrollmentsAsync(CreateCourseWithStudentsDTO dto)
    {
        var course = new Course
        {
            Title = dto.Title,
            Credits = dto.Credits,
            Teacher = dto.Teacher
        };
        _context.Courses.Add(course);
        await _context.SaveChangesAsync();

        var enrollments = new List<EnrollmentResultDTO>();
        foreach (var studentDto in dto.Students)
        {
            var student = await _context.Students
                .FirstOrDefaultAsync(s => s.FirstName == studentDto.FirstName &&
                                          s.LastName == studentDto.LastName &&
                                          s.Email == studentDto.Email);

            if (student == null)
            {
                student = new Student
                {
                    FirstName = studentDto.FirstName,
                    LastName = studentDto.LastName,
                    Email = studentDto.Email
                };
                _context.Students.Add(student);
                await _context.SaveChangesAsync();
            }

            var enrollment = new Enrollment
            {
                StudentId = student.Id,
                CourseId = course.Id,
                EnrollmentDate = DateTime.Now
            };
            _context.Enrollments.Add(enrollment);
            await _context.SaveChangesAsync();

            enrollments.Add(new EnrollmentResultDTO
            {
                StudentId = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                EnrollmentDate = enrollment.EnrollmentDate
            });
        }

        return new CreatedCourseResponseDTO
        {
            Message = "Kurs zostal utworzony i studenci zostali zapisani.",
            Course = new CourseDTO
            {
                Id = course.Id,
                Title = course.Title,
                Teacher = course.Teacher
            },
            Enrollments = enrollments
        };
    }
}
