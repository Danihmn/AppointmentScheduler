namespace AppointmentScheduler.Application.Queries.Request;

public record GetRequestsQuery () : IQuery<IEnumerable<RequestResponseDTO>>;