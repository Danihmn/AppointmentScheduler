namespace AppointmentScheduler.Application.Queries.Specialty
{
    public record GetSpecialtyByIdQuery (int Id) : IQuery<Domain.Entities.Specialty>;
}
