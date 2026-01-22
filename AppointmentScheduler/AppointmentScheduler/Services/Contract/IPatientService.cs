using AppointmentScheduler.Domain.Entities;
using AppointmentScheduler.Domain.Enums;

namespace AppointmentScheduler.Services.Contract;

public interface IPatientService
{
    Task<Patient> CreatePatientAsync(
        string name, string cpf, string phoneNumber, string email, EGender gender, string? notes,
        CancellationToken cancellationToken = default);
}