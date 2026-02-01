using AppointmentScheduler.Common;
using AppointmentScheduler.Domain.Interfaces;

namespace AppointmentScheduler.Queries.Request
{
    public class GetRequestsQueryHandler (IUnitOfWork unitOfWork) :
        IQueryHandler<GetRequestsQuery, IEnumerable<Domain.Entities.Request>>
    {
        public async Task<IEnumerable<Domain.Entities.Request>> Handle
            (GetRequestsQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var requestRepository = unitOfWork.GetRepository<Domain.Entities.Request>();
                return await requestRepository.GetAllAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while getting Requests", ex);
            }
        }
    }
}
