namespace AppointmentScheduler.Application.Queries.Appointment
{
    public record GetAppointmentByIdQuery (int Id) : IQuery<AppointmentResponseDTO>;
}
