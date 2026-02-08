namespace AppointmentScheduler.Application.Queries.Specialty
{
    public record GetSpecialtyByIdQuery (int Id) : IQuery<SpecialtyResponseDTO>;
}
