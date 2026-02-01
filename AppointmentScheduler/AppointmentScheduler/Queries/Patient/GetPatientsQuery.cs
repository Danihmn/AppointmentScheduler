namespace AppointmentScheduler.Queries.Patient
{
    public record GetPatientsQuery () : IQuery<IEnumerable<Domain.Entities.Patient>>;
}
