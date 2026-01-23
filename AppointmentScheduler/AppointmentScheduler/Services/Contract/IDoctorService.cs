using AppointmentScheduler.Domain.Entities;

namespace AppointmentScheduler.Services.Contract;

public interface IDoctorService
{
    Task<Doctor> CreateDoctorAsync
    (
        string name,
        string crm,
        string phoneNumber,
        string email,
        DateTime hiringDate,
        bool active,
        int specialtyId,
        CancellationToken cancellationToken = default
    );
}