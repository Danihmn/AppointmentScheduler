namespace AppointmentScheduler.Features.Request.Get.GetById
{
    public class GetRequestByIdQueryHandler (IUnitOfWork unitOfWork, IMapper mapper) :
        IQueryHandler<GetRequestByIdQuery, ApiResponse<RequestResponseDTO>>
    {
        public async Task<ApiResponse<RequestResponseDTO>> Handle
            (GetRequestByIdQuery query, CancellationToken cancellationToken)
        {
            var requestRepository = await unitOfWork.RequestRepository.GetAllWithDetailAsync(cancellationToken);

            return requestRepository is null ?
                throw new NotFoundException(nameof(RequestResponseDTO), query.Id)
                : ApiResponse<RequestResponseDTO>.Ok(mapper.Map<RequestResponseDTO>(requestRepository));
        }
    }
}
