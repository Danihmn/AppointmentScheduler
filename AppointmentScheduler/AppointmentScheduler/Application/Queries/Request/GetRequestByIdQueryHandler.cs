namespace AppointmentScheduler.Application.Queries.Request
{
    public class GetRequestByIdQueryHandler (IUnitOfWork unitOfWork, IMapper mapper) :
        IQueryHandler<GetRequestByIdQuery, RequestResponseDTO>
    {
        public async Task<RequestResponseDTO> Handle
            (GetRequestByIdQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var requestRepository
                    = await unitOfWork.RequestRepository.GetByIdWithDetailsAsync(query.Id, cancellationToken);

                return requestRepository == null ? throw new Exception()
                    : mapper.Map<RequestResponseDTO>(requestRepository);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while getting Request", ex);
            }
        }
    }
}
