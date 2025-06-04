namespace kolos2.Models;

public class Course
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Credits { get; set; } = string.Empty;
    public string Teacher { get; set; } = string.Empty;

    public ICollection<Enrollment> Enrollments { get; set; } = new HashSet<Enrollment>();
}