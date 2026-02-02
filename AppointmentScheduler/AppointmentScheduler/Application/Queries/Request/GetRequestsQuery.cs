using AppointmentScheduler.Application.Common;

namespace AppointmentScheduler.Application.Queries.Request;

public record GetRequestsQuery () : IQuery<IEnumerable<Domain.Entities.Request>>;