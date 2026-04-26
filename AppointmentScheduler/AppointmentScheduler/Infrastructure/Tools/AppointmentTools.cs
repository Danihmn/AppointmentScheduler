namespace AppointmentScheduler.Infrastructure.Tools;

public class AppointmentTools
    (
    IQueryHandler<GetAppointmentsQuery, ApiResponse<IEnumerable<AppointmentResponseDTO>>> getAllAppointmentsHandler,
    IQueryHandler<GetAppointmentByIdQuery, ApiResponse<AppointmentResponseDTO>> getAppointmentByIdQueryHandler,
    ICommandHandler<ScheduleAppointmentCommand, ApiResponse<AppointmentResponseDTO>> scheduleAppointmentCommandHandler,
    ICommandHandler<UpdateAppointmentCommand, ApiResponse<AppointmentResponseDTO>> updateAppointmentCommandHandler
    )
{
    #region Queries
    [Description("Lists all appointments. Use this when the user asks to list all the appointments.")]
    public async Task<ApiResponse<IEnumerable<AppointmentResponseDTO>>> GetAllAppointmentsAsync (
        CancellationToken cancellationToken = default)
    => await getAllAppointmentsHandler.Handle(new GetAppointmentsQuery(), cancellationToken);

    [Description("Search appointment by Id. Use when the user asks for a specific appointment.")]
    public async Task<ApiResponse<AppointmentResponseDTO>> GetAppointmentByIdAsync (
        [Description("The Id of the appointment to search for.")] int id,
        CancellationToken cancellationToken = default)
    => await getAppointmentByIdQueryHandler.Handle(new GetAppointmentByIdQuery(id), cancellationToken);
    #endregion

    #region Commands
    [Description("Creates a new appointment. Use this when the user asks to schedule an appointment.")]
    public async Task<ApiResponse<AppointmentResponseDTO>> CreateAppointmentAsync (
        [Description("The details of the appointment to create.")] ScheduleAppointmentCommand command,
        CancellationToken cancellationToken = default)
    => await scheduleAppointmentCommandHandler.Handle(command, cancellationToken);

    [Description("Updates an existing appointment. Use this when the user asks to update an appointment.")]
    public async Task<ApiResponse<AppointmentResponseDTO>> UpdateAppointmentAsync (
        [Description("The details of the appointment to update.")] UpdateAppointmentCommand command,
        CancellationToken cancellationToken = default)
    => await updateAppointmentCommandHandler.Handle(command, cancellationToken);
    #endregion
}
