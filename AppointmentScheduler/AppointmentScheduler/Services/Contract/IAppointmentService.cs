using AppointmentScheduler.Domain.Entities;

namespace AppointmentScheduler.Services.Contract;

public interface IAppointmentService
{
    Task<Appointment> ScheduleAppointmentAsync(
        DateTime date,
        int patientId,
        int doctorId,
        int specialtyId,
        int secretaryId,
        string? notes = null,
        CancellationToken cancellationToken = default);

    Task<Appointment?> GetAppointmentAsync(int id, CancellationToken cancellationToken = default);
}