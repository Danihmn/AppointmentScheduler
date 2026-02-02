namespace AppointmentScheduler.Application.Queries.Specialty
{
    public record GetSpecialtiesQuery () : IQuery<IEnumerable<Domain.Entities.Specialty>>;
}
