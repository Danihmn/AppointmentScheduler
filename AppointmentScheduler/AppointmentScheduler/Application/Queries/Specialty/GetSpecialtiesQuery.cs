namespace AppointmentScheduler.Application.Queries.Specialty
{
    public record GetSpecialtiesQuery () : IQuery<IEnumerable<SpecialtyResponseDTO>>;
}
