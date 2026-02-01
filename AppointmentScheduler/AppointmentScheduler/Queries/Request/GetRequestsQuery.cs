namespace AppointmentScheduler.Queries.Request;

public record GetRequestsQuery () : IQuery<IEnumerable<Domain.Entities.Request>>;