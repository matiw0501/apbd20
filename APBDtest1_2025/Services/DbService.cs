using System.Data.Common;
using APBD_example_test1_2025.Exceptions;
using APBD_example_test1_2025.Models.DTOs;
using Microsoft.Data.SqlClient;

namespace APBD_example_test1_2025.Services;

public class DbService : IDbService
{
    private readonly string _connectionString;

    public DbService(IConfiguration configuration)
    {
        // _connectionString = configuration.GetConnectionString("Default")!;
        _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=APBD;Integrated Security=True;";
    }

    public async Task<AppointmentDto> GetAppointmentByIdAsync(int id)
    {
        const string query = @"
            SELECT a.date, 
                   p.first_name, p.last_name, p.date_of_birth,
                   d.doctor_id, d.pwz,
                   s.name, aps.service_fee
            FROM Appointment a
            JOIN Patient p ON a.patient_id = p.patient_id
            JOIN Doctor d ON a.doctor_id = d.doctor_id
            JOIN Appointment_Service aps ON aps.appoitment_id = a.appoitment_id
            JOIN Service s ON aps.service_id = s.service_id
            WHERE a.appoitment_id = @id";

        await using var conn = new SqlConnection(_connectionString);
        await using var cmd = new SqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@id", id);
        await conn.OpenAsync();

        var reader = await cmd.ExecuteReaderAsync();

        AppointmentDto? appointment = null;
        while (await reader.ReadAsync())
        {
            if (appointment is null)
            {
                appointment = new AppointmentDto
                {
                    Date = reader.GetDateTime(0),
                    Patient = new PatientDto
                    {
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        DateOfBirth = reader.GetDateTime(3)
                    },
                    Doctor = new DoctorDto
                    {
                        DoctorId = reader.GetInt32(4),
                        Pwz = reader.GetString(5)
                    },
                    AppointmentServices = new List<ServiceDto>()
                };
            }

            appointment.AppointmentServices.Add(new ServiceDto
            {
                Name = reader.GetString(6),
                ServiceFee = reader.GetDecimal(7)
            });
        }

        if (appointment is null)
            throw new NotFoundException("Appoitment not found.");

        return appointment;
    }

    public async Task AddAppointmentAsync(CreateAppointmentDto dto)
    {
        await using var connection = new SqlConnection(_connectionString);
        await using SqlCommand command = new SqlCommand();
        command.Connection = connection;
        await connection.OpenAsync();

        DbTransaction transaction = await connection.BeginTransactionAsync();
        command.Transaction = transaction as SqlTransaction;
        try
        {
            command.Parameters.Clear();
            command.CommandText = "SELECT 1 FROM Appointment WHERE appoitment_id = @id";
            command.Parameters.AddWithValue("@id", dto.AppoitmentId);
            if (await command.ExecuteScalarAsync() is not null)
                throw new ConflictException("Appoitment already exists.");
            
            command.Parameters.Clear();
            command.CommandText = "SELECT 1 FROM Patient WHERE patient_id = @pid";
            command.Parameters.AddWithValue("@pId", dto.PatientId);
            if (await command.ExecuteScalarAsync() is null)
                throw new NotFoundException("Patient not found.");
            
            command.Parameters.Clear();
            command.CommandText = "SELECT doctor_id FROM Doctor WHERE pwz = @pwz";
            command.Parameters.AddWithValue("@pwz", dto.Pwz);
            var doctorId = await command.ExecuteScalarAsync();
            if (doctorId is null)
                throw new NotFoundException("Doctor not found.");
            
            command.Parameters.Clear();
            command.CommandText = @"
                INSERT INTO Appointment (appoitment_id, date, patient_id, doctor_id)
                VALUES (@aid, GETDATE(), @pid, @did)";
            command.Parameters.AddWithValue("@aId", dto.AppoitmentId);
            command.Parameters.AddWithValue("@pId", dto.PatientId);
            command.Parameters.AddWithValue("@dId", doctorId);
            await command.ExecuteNonQueryAsync();
            
            foreach (var service in dto.Services)
            {
                command.Parameters.Clear();
                command.CommandText = "SELECT service_id FROM Service WHERE name = @name";
                command.Parameters.AddWithValue("@name", service.ServiceName);
                var serviceId = await command.ExecuteScalarAsync();
                if (serviceId is null)
                    throw new NotFoundException($"Service {service.ServiceName} not found.");

                command.Parameters.Clear();
                command.CommandText = "INSERT INTO Appointment_Service VALUES (@aid, @sid, @fee)";
                command.Parameters.AddWithValue("@aid", dto.AppoitmentId);
                command.Parameters.AddWithValue("@sid", serviceId);
                command.Parameters.AddWithValue("@fee", service.ServiceFee);
                
                await command.ExecuteNonQueryAsync();
            }

            await transaction.CommitAsync();
        }
        catch(Exception e)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}