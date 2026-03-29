namespace AppointmentScheduler.Features.Patient.Get.GetAll
{
    public class GetPatientsQueryHandler (IUnitOfWork unitOfWork, IMapper mapper) :
        IQueryHandler<GetPatientsQuery, ApiResponse<IEnumerable<PatientResponseDTO>>>
    {
        public async Task<ApiResponse<IEnumerable<PatientResponseDTO>>> Handle
            (GetPatientsQuery query, CancellationToken cancellationToken)
        {
            var patientRepository = await unitOfWork.PatientRepository.GetAllWithDetailAsync(cancellationToken);

            return patientRepository is null ?
                throw new NotFoundException(nameof(Patient), null)
                : ApiResponse<IEnumerable<PatientResponseDTO>>.Ok(mapper.Map<IEnumerable<PatientResponseDTO>>(patientRepository));
        }
    }
}
