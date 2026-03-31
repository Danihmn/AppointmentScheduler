namespace AppointmentScheduler.Features.Request.Get.GetAll
{
    public class GetRequestsQueryHandler (IUnitOfWork unitOfWork, IMapper mapper) :
        IQueryHandler<GetRequestsQuery, ApiResponse<IEnumerable<RequestResponseDTO>>>
    {
        public async Task<ApiResponse<IEnumerable<RequestResponseDTO>>> Handle
            (GetRequestsQuery query, CancellationToken cancellationToken)
        {
            var requestRepository = await unitOfWork.RequestRepository.GetAllWithDetailAsync(cancellationToken);

            return requestRepository is null ?
                throw new NotFoundException(nameof(RequestResponseDTO), null)
                : ApiResponse<IEnumerable<RequestResponseDTO>>.Ok(mapper.Map<IEnumerable<RequestResponseDTO>>(requestRepository));
        }
    }
}
