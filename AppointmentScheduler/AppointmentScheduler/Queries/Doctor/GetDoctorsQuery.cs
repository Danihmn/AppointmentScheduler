namespace AppointmentScheduler.Queries.Doctor
{
    public record GetDoctorsQuery () : IQuery<IEnumerable<Domain.Entities.Doctor>>;
}
