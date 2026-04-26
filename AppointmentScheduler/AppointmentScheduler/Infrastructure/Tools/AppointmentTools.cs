namespace AppointmentScheduler.Infrastructure.Tools
{
    public class AppointmentTools
        (IQueryHandler<GetAppointmentsQuery, ApiResponse<IEnumerable<AppointmentResponseDTO>>> getAllAppointmentsHandler)
    {
        [Description("Lists all appointments. Use this when the user asks to list all the appointments.")]
        public async Task<ApiResponse<IEnumerable<AppointmentResponseDTO>>> GetAllAppointmentsAsync (
            CancellationToken cancellationToken = default)
        => await getAllAppointmentsHandler.Handle(new GetAppointmentsQuery(), cancellationToken);
    }
}