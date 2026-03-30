namespace AppointmentScheduler.Features.Doctor.Get.GetAll
{
    public class GetDoctorsQueryHandler (IUnitOfWork unitOfWork, IMapper mapper)
        : IQueryHandler<GetDoctorsQuery, ApiResponse<IEnumerable<DoctorResponseDTO>>>
    {
        public async Task<ApiResponse<IEnumerable<DoctorResponseDTO>>> Handle
            (GetDoctorsQuery query, CancellationToken cancellationToken)
        {
            var doctorRepository = await unitOfWork.DoctorRepository.GetAllWithDetailAsync(cancellationToken);

            return doctorRepository is null ?
                throw new NotFoundException(nameof(DoctorResponseDTO), null)
                : ApiResponse<IEnumerable<DoctorResponseDTO>>.Ok(mapper.Map<IEnumerable<DoctorResponseDTO>>(doctorRepository));
        }
    }
}
