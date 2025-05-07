namespace APBD_example_test1_2025.Models.DTOs;

public class AppointmentDto
{
    public DateTime Date { get; set; }
    public PatientDto Patient { get; set; } = null!;
    public DoctorDto Doctor { get; set; } = null!;
    public List<ServiceDto> AppointmentServices { get; set; } = new();
}

public class PatientDto
{
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public DateTime DateOfBirth { get; set; }
}

public class DoctorDto
{
    public int DoctorId { get; set; }
    public string Pwz { get; set; } = "";
}

public class ServiceDto
{
    public string Name { get; set; } = "";
    public decimal ServiceFee { get; set; }
}

public class CreateAppointmentDto
{
    public int AppoitmentId { get; set; }
    public int PatientId { get; set; }
    public string Pwz { get; set; } = "";
    public List<CreateServiceDto> Services { get; set; } = new();
}

public class CreateServiceDto
{
    public string ServiceName { get; set; } = "";
    public decimal ServiceFee { get; set; }
}