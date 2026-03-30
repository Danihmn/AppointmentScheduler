namespace AppointmentScheduler.Features.Specialty.Get.GetById
{
    public class GetSpecialtyByIdQueryHandler (IUnitOfWork unitOfWork, IMapper mapper)
        : IQueryHandler<GetSpecialtyByIdQuery, ApiResponse<SpecialtyResponseDTO>>
    {
        public async Task<ApiResponse<SpecialtyResponseDTO>> Handle
            (GetSpecialtyByIdQuery query, CancellationToken cancellationToken)
        {
            var specialtyRepository = await unitOfWork.SpecialtyRepository.GetAllWithDetailAsync(cancellationToken);

            return specialtyRepository is null ?
                throw new NotFoundException(nameof(SpecialtyResponseDTO), query.Id)
                : ApiResponse<SpecialtyResponseDTO>.Ok(mapper.Map<SpecialtyResponseDTO>(specialtyRepository));
        }
    }
}
