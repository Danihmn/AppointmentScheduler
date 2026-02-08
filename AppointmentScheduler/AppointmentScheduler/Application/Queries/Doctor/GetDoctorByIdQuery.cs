namespace AppointmentScheduler.Application.Queries.Doctor
{
    public record GetDoctorByIdQuery (int Id) : IQuery<DoctorResponseDTO>;
}
