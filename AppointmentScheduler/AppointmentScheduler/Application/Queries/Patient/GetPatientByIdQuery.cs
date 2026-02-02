using AppointmentScheduler.Application.Common;

namespace AppointmentScheduler.Application.Queries.Patient
{
    public record GetPatientByIdQuery (int Id) : IQuery<Domain.Entities.Patient>;
}
