using AppointmentScheduler.Features.Common.CQRS;
using AppointmentScheduler.Infraestructure.Persistence.UnifOfWork;

namespace AppointmentScheduler.Features.Request.Get.GetAll
{
    public class GetRequestsQueryHandler (IUnitOfWork unitOfWork, IMapper mapper) :
        IQueryHandler<GetRequestsQuery, IEnumerable<RequestResponseDTO>>
    {
        public async Task<IEnumerable<RequestResponseDTO>> Handle
            (GetRequestsQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var requestRepository
                    = await unitOfWork.RequestRepository.GetAllWithDetailAsync(cancellationToken);

                return mapper.Map<IEnumerable<RequestResponseDTO>>(requestRepository);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while getting Requests", ex);
            }
        }
    }
}
