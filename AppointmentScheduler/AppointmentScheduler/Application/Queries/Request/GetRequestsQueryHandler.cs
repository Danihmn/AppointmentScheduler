namespace AppointmentScheduler.Application.Queries.Request
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
