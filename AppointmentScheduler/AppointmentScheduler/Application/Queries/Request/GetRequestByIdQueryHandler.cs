namespace AppointmentScheduler.Application.Queries.Request
{
    public class GetRequestByIdQueryHandler (IUnitOfWork unitOfWork) :
        IQueryHandler<GetRequestByIdQuery, Domain.Entities.Request>
    {
        public async Task<Domain.Entities.Request> Handle (GetRequestByIdQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var requestRepository = unitOfWork.GetRepository<Domain.Entities.Request>();
                return await requestRepository.GetByIdAsync(query.Id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while getting Request", ex);
            }
        }
    }
}
