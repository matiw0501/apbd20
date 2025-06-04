namespace kolos2.DTOs;

public class EnrollmentDTO
{
    public StudentDTO Student { get; set; } = null!;
    public CourseDTO Course { get; set; } = null!;
    public DateTime EnrollmentDate { get; set; }
}
