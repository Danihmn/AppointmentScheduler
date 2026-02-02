using AppointmentScheduler.Application.Common;

namespace AppointmentScheduler.Application.Queries.Secretary
{
    public record GetSecretariesQuery () : IQuery<IEnumerable<Domain.Entities.Secretary>>;
}
