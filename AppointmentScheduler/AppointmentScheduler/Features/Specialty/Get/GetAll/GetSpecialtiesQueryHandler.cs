using AppointmentScheduler.Features.Common.CQRS;
using AppointmentScheduler.Infraestructure.Persistence.UnifOfWork;

namespace AppointmentScheduler.Features.Specialty.Get.GetAll
{
    public class GetSpecialtiesQueryHandler (IUnitOfWork unitOfWork, IMapper mapper)
        : IQueryHandler<GetSpecialtiesQuery, IEnumerable<SpecialtyResponseDTO>>
    {
        public async Task<IEnumerable<SpecialtyResponseDTO>> Handle
            (GetSpecialtiesQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var specialtyRepository
                    = await unitOfWork.SpecialtyRepository.GetAllWithDetailAsync(cancellationToken);

                return mapper.Map<IEnumerable<SpecialtyResponseDTO>>(specialtyRepository);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while getting Specialties", ex);
            }
        }
    }
}
