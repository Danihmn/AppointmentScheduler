namespace AppointmentScheduler.Application.Queries.Secretary
{
    public class GetSecretaryByIdQueryHandler (IUnitOfWork unitOfWork, IMapper mapper)
        : IQueryHandler<GetSecretaryByIdQuery, SecretaryResponseDTO>
    {
        public async Task<SecretaryResponseDTO> Handle
            (GetSecretaryByIdQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var secretaryRepository
                    = unitOfWork.SecretaryRepository.GetByIdWithDetailsAsync(query.Id, cancellationToken);

                return secretaryRepository == null ? throw new Exception()
                    : mapper.Map<SecretaryResponseDTO>(secretaryRepository);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while getting Secretary", ex);
            }
        }
    }
}
