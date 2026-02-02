namespace AppointmentScheduler.Infraestructure.Services.Contract;

public interface IAppointmentService
{
    Task<IEnumerable<Appointment>> GetAppointmentsAsync (CancellationToken cancellationToken = default);
    Task<Appointment> GetAppointmentByIdAsync (int id, CancellationToken cancellationToken = default);
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