namespace AppointmentScheduler.Features.Doctor.Get.GetById
{
    public class GetDoctorByIdQueryHandler (IUnitOfWork unitOfWork, IMapper mapper)
        : IQueryHandler<GetDoctorByIdQuery, ApiResponse<DoctorResponseDTO>>
    {
        public async Task<ApiResponse<DoctorResponseDTO>> Handle (GetDoctorByIdQuery query, CancellationToken cancellationToken)
        {
            var doctorRepository = await unitOfWork.DoctorRepository.GetAllWithDetailAsync(cancellationToken);

            return doctorRepository is null ?
                throw new NotFoundException(nameof(DoctorResponseDTO), query.Id)
                : ApiResponse<DoctorResponseDTO>.Ok(mapper.Map<DoctorResponseDTO>(doctorRepository));
        }
    }
}
