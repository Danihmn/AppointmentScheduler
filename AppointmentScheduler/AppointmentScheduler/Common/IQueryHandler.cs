namespace AppointmentScheduler.Common;

public interface IQueryHandler<TQuery, TResponse> where TQuery : IQuery<TResponse>
{
    Task<TResponse> Handle (TQuery query, CancellationToken cancellationToken);
    Task<TResponse> Handle (CancellationToken cancellationToken);
}