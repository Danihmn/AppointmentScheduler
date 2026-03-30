namespace AppointmentScheduler.Features.Specialty.Get.GetAll
{
    public class GetSpecialtiesQueryHandler (IUnitOfWork unitOfWork, IMapper mapper)
        : IQueryHandler<GetSpecialtiesQuery, ApiResponse<IEnumerable<SpecialtyResponseDTO>>>
    {
        public async Task<ApiResponse<IEnumerable<SpecialtyResponseDTO>>> Handle
            (GetSpecialtiesQuery query, CancellationToken cancellationToken)
        {
            var specialtyRepository = await unitOfWork.SpecialtyRepository.GetAllWithDetailAsync(cancellationToken);

            return specialtyRepository is null ?
                throw new NotFoundException(nameof(SpecialtyResponseDTO), null)
                : ApiResponse<IEnumerable<SpecialtyResponseDTO>>.Ok(mapper.Map<IEnumerable<SpecialtyResponseDTO>>(specialtyRepository));
        }
    }
}
