using AppointmentScheduler.Application.Common;

namespace AppointmentScheduler.Application.Queries.Patient
{
    public record GetPatientsQuery () : IQuery<IEnumerable<Domain.Entities.Patient>>;
}
