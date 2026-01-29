using AppointmentScheduler.Common;

namespace AppointmentScheduler.Queries.Doctor
{
    public record GetDoctorByIdQuery (int Id) : IQuery<Domain.Entities.Doctor>;
}
