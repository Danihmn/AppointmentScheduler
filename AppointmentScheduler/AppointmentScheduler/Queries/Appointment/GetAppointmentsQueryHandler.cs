using AppointmentScheduler.Common;
using AppointmentScheduler.Domain.Interfaces;

namespace AppointmentScheduler.Queries.Appointment
{
    public class GetAppointmentsQueryHandler (IUnitOfWork unitOfWork)
        : IQueryHandler<GetAppointmentsQuery, IEnumerable<Domain.Entities.Appointment>>
    {
        public async Task<IEnumerable<Domain.Entities.Appointment>> Handle (
            GetAppointmentsQuery query,
            CancellationToken cancellationToken)
        {
            try
            {
                var appointmentRepository = unitOfWork.GetRepository<Domain.Entities.Appointment>();
                return await appointmentRepository.GetAllAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while getting Appointments", ex);
            }
        }
    }
}
