using AppointmentScheduler.Application.Common;

namespace AppointmentScheduler.Application.Queries.Patient
{
    public class GetPatientByIdQueryHandler (IUnitOfWork unitOfWork)
        : IQueryHandler<GetPatientByIdQuery, Domain.Entities.Patient>
    {
        public async Task<Domain.Entities.Patient> Handle
            (GetPatientByIdQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var patientRepository = unitOfWork.GetRepository<Domain.Entities.Patient>();
                return await patientRepository.GetByIdAsync(query.Id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while getting Patient", ex);
            }
        }
    }
}
