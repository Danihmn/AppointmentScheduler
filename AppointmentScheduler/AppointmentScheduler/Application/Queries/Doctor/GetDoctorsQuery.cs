using AppointmentScheduler.Application.Common;

namespace AppointmentScheduler.Application.Queries.Doctor
{
    public record GetDoctorsQuery () : IQuery<IEnumerable<Domain.Entities.Doctor>>;
}
