namespace AppointmentScheduler.Queries.Patient
{
    public record GetPatientByIdQuery (int Id) : IQuery<Domain.Entities.Patient>;
}
