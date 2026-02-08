namespace AppointmentScheduler.Application.Queries.Patient
{
    public class GetPatientByIdQueryHandler (IUnitOfWork unitOfWork, IMapper mapper)
        : IQueryHandler<GetPatientByIdQuery, PatientResponseDTO>
    {
        public async Task<PatientResponseDTO> Handle
            (GetPatientByIdQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var patientRepository
                    = await unitOfWork.PatientRepository.GetByIdWithDetailsAsync(query.Id, cancellationToken);

                return patientRepository == null ? throw new Exception()
                    : mapper.Map<PatientResponseDTO>(patientRepository);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while getting Patient", ex);
            }
        }
    }
}
