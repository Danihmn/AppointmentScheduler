namespace AppointmentScheduler.Features.Patient.Get.GetById
{
    public class GetPatientByIdQueryHandler (IUnitOfWork unitOfWork, IMapper mapper)
        : IQueryHandler<GetPatientByIdQuery, ApiResponse<PatientResponseDTO>>
    {
        public async Task<ApiResponse<PatientResponseDTO>> Handle
            (GetPatientByIdQuery query, CancellationToken cancellationToken)
        {
            var patientRepository = await unitOfWork.PatientRepository.GetByIdWithDetailsAsync(query.Id, cancellationToken);

            return patientRepository is null
                ? throw new NotFoundException(nameof(PatientResponseDTO), query.Id)
                : ApiResponse<PatientResponseDTO>.Ok(
                    mapper.Map<PatientResponseDTO>(patientRepository));
        }
    }
}
