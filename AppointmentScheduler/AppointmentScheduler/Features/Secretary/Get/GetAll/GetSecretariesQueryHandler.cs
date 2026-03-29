namespace AppointmentScheduler.Features.Secretary.Get.GetAll
{
    public class GetSecretariesQueryHandler (IUnitOfWork unitOfWork, IMapper mapper)
        : IQueryHandler<GetSecretariesQuery, ApiResponse<IEnumerable<SecretaryResponseDTO>>>
    {
        public async Task<ApiResponse<IEnumerable<SecretaryResponseDTO>>> Handle
            (GetSecretariesQuery query, CancellationToken cancellationToken)
        {
            var secretaryRepository = await unitOfWork.SecretaryRepository.GetAllWithDetailAsync(cancellationToken);

            return secretaryRepository is null ?
                throw new NotFoundException(nameof(SecretaryResponseDTO), null)
                : ApiResponse<IEnumerable<SecretaryResponseDTO>>.Ok(mapper.Map<IEnumerable<SecretaryResponseDTO>>(secretaryRepository));
        }
    }
}
