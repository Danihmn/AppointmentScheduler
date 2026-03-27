using AppointmentScheduler.Features.Common.CQRS;
using AppointmentScheduler.Infraestructure.Persistence.UnifOfWork;

namespace AppointmentScheduler.Features.Secretary.Get.GetById
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
