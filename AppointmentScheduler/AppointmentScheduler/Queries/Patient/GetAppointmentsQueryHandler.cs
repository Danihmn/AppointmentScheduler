namespace AppointmentScheduler.Queries.Patient
{
    public class GetPatientsQueryHandler (IUnitOfWork unitOfWork) :
        IQueryHandler<GetPatientsQuery, IEnumerable<Domain.Entities.Patient>>
    {
        public async Task<IEnumerable<Domain.Entities.Patient>> Handle
            (GetPatientsQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var patientRepository = unitOfWork.GetRepository<Domain.Entities.Patient>();
                return await patientRepository.GetAllAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while getting Patients", ex);
            }
        }
    }
}
