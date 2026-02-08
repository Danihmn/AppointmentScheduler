namespace AppointmentScheduler.Application.Queries.Doctor
{
    public record GetDoctorsQuery () : IQuery<IEnumerable<DoctorResponseDTO>>;
}
