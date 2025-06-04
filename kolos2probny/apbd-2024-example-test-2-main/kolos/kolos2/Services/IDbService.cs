

using kolos2.DTOs;
using kolos2.Models;

namespace kolos2.Services;

public interface IDbService
{
    Task<IEnumerable<Enrollment>> GetEnrollmentsAsync();
    Task<CreatedCourseResponseDTO> AddCourseWithEnrollmentsAsync(CreateCourseWithStudentsDTO dto);
}