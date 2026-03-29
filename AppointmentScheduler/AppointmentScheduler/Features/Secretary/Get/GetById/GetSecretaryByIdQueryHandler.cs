namespace AppointmentScheduler.Features.Secretary.Get.GetById
{
    public class GetSecretaryByIdQueryHandler (IUnitOfWork unitOfWork, IMapper mapper)
        : IQueryHandler<GetSecretaryByIdQuery, ApiResponse<SecretaryResponseDTO>>
    {
        public async Task<ApiResponse<SecretaryResponseDTO>> Handle
            (GetSecretaryByIdQuery query, CancellationToken cancellationToken)
        {
            var secretaryRepository = await unitOfWork.SecretaryRepository.GetAllWithDetailAsync(cancellationToken);

            return secretaryRepository is null ?
                throw new NotFoundException(nameof(SecretaryResponseDTO), query.Id)
                : ApiResponse<SecretaryResponseDTO>.Ok(mapper.Map<SecretaryResponseDTO>(secretaryRepository));
        }
    }
}
