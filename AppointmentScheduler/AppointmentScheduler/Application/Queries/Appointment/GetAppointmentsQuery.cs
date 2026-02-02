namespace AppointmentScheduler.Application.Queries.Appointment
{
    public record GetAppointmentsQuery () : IQuery<IEnumerable<Domain.Entities.Appointment>>;
}
