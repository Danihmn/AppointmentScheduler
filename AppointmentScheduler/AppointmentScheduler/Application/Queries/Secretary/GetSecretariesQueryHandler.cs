namespace AppointmentScheduler.Application.Queries.Secretary
{
    public class GetSecretariesQueryHandler (IUnitOfWork unitOfWork, IMapper mapper)
        : IQueryHandler<GetSecretariesQuery, IEnumerable<SecretaryResponseDTO>>
    {
        public async Task<IEnumerable<SecretaryResponseDTO>> Handle
            (GetSecretariesQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var secretaryRepository
                    = await unitOfWork.SecretaryRepository.GetAllWithDetailAsync(cancellationToken);

                return mapper.Map<IEnumerable<SecretaryResponseDTO>>(secretaryRepository);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while getting Secretaries", ex);
            }
        }
    }
}
