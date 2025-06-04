namespace kolos2.DTOs;

public class CreatedCourseResponseDTO
{
    public string Message { get; set; } = "";
    public CourseDTO Course { get; set; } = null!;
    public List<EnrollmentResultDTO> Enrollments { get; set; } = new();
}