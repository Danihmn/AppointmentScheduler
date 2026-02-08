namespace AppointmentScheduler.Application.Queries.Patient
{
    public record GetPatientsQuery () : IQuery<IEnumerable<PatientResponseDTO>>;
}
