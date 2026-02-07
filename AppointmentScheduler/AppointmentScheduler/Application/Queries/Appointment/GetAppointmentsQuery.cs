namespace AppointmentScheduler.Application.Queries.Appointment
{
    public record GetAppointmentsQuery () : IQuery<IEnumerable<AppointmentResponseDTO>>;
}
