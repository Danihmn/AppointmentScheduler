using AppointmentScheduler.Domain.Entities;
using AppointmentScheduler.Domain.Enums;

namespace AppointmentScheduler.Services.Contract;

public interface IAppointmentService
{
    Task<Appointment> ScheduleAppointmentAsync
    (
        DateTime date,
        EStatus status,
        int requestId,
        int patientId,
        int doctorId,
        int specialtyId,
        int secretaryId,
        string? notes = null,
        CancellationToken cancellationToken = default
    );
}