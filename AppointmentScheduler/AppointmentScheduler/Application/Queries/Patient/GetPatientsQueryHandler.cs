namespace AppointmentScheduler.Application.Queries.Patient
{
    public class GetPatientsQueryHandler (IUnitOfWork unitOfWork, IMapper mapper) :
        IQueryHandler<GetPatientsQuery, IEnumerable<PatientResponseDTO>>
    {
        public async Task<IEnumerable<PatientResponseDTO>> Handle
            (GetPatientsQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var patientRepository
                    = await unitOfWork.PatientRepository.GetAllWithDetailAsync(cancellationToken);

                return mapper.Map<IEnumerable<PatientResponseDTO>>(patientRepository);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while getting Patients", ex);
            }
        }
    }
}
