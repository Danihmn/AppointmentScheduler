namespace AppointmentScheduler.Infraestructure.Services.Implementation;

public class AppointmentService
    (
        IQueryHandler<GetAppointmentsQuery, IEnumerable<AppointmentResponseDTO>> queryHandlerGetAllAppointments,
        IQueryHandler<GetAppointmentByIdQuery, AppointmentResponseDTO> queryHandlerGetAppointmentById,
        ICommandHandler<ScheduleAppointmentCommand, Appointment> commandHandlerCreateAppointment
    )
    : IAppointmentService
{
    public async Task<IEnumerable<AppointmentResponseDTO>> GetAppointmentsAsync (CancellationToken cancellationToken = default)
    {
        var query = new GetAppointmentsQuery();
        return await queryHandlerGetAllAppointments.Handle(query, cancellationToken);
    }

    public async Task<AppointmentResponseDTO> GetAppointmentByIdAsync (int id, CancellationToken cancellationToken = default)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);

        var query = new GetAppointmentByIdQuery(id);
        return await queryHandlerGetAppointmentById.Handle(query, cancellationToken);
    }

    public async Task<Appointment> ScheduleAppointmentAsync (DateTime date, EStatus status, int requestId, int patientId,
        int doctorId,
        int specialtyId, int secretaryId, string? notes = null, CancellationToken cancellationToken = default)
    {
        if (date < DateTime.Now) throw new Exception("Invalid date");

        var command = new ScheduleAppointmentCommand(date, status, requestId, patientId, doctorId, specialtyId,
            secretaryId, notes);

        return await commandHandlerCreateAppointment.Handle(command, cancellationToken);
    }
}