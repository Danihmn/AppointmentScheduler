using AppointmentScheduler.Application.Common;

namespace AppointmentScheduler.Application.Queries.Secretary
{
    public record GetSecretaryByIdQuery (int Id) : IQuery<Domain.Entities.Secretary>;
}
