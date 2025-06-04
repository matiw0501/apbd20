namespace kolos2.DTOs;


public class CreateCourseWithStudentsDTO
{
    public string Title { get; set; } = string.Empty;
    public string Credits { get; set; } = string.Empty;
    public string Teacher { get; set; } = string.Empty;
    public List<CreateStudentDTO> Students { get; set; } = new();
}