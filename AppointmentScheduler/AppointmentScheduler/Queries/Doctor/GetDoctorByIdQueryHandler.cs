using AppointmentScheduler.Common;
using AppointmentScheduler.Domain.Interfaces;

namespace AppointmentScheduler.Queries.Doctor
{
    public class GetDoctorByIdQueryHandler (IUnitOfWork unitOfWork)
        : IQueryHandler<GetDoctorByIdQuery, Domain.Entities.Doctor>
    {
        public async Task<Domain.Entities.Doctor> Handle (GetDoctorByIdQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var doctorRepository = unitOfWork.GetRepository<Domain.Entities.Doctor>();
                return await doctorRepository.GetByIdAsync(query.Id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while getting Doctor", ex);
            }
        }
    }
}
