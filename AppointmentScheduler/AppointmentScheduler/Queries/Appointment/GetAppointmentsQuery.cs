namespace AppointmentScheduler.Queries.Appointment
{
    public record GetAppointmentsQuery () : IQuery<IEnumerable<Domain.Entities.Appointment>>;
}
