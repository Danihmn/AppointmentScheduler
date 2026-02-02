using AppointmentScheduler.Application.Common;

namespace AppointmentScheduler.Application.Queries.Doctor
{
    public record GetDoctorByIdQuery (int Id) : IQuery<Domain.Entities.Doctor>;
}
