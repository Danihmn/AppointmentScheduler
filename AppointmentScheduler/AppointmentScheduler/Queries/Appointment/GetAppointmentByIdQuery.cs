namespace AppointmentScheduler.Queries.Appointment
{
    public record GetAppointmentByIdQuery (int Id) : IQuery<Domain.Entities.Appointment>;
}
