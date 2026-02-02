using AppointmentScheduler.Application.Common;

namespace AppointmentScheduler.Application.Queries.Appointment
{
    public class GetAppointmentByIdQueryHandler (IUnitOfWork unitOfWork)
        : IQueryHandler<GetAppointmentByIdQuery, Domain.Entities.Appointment>
    {
        public async Task<Domain.Entities.Appointment> Handle (
            GetAppointmentByIdQuery query,
            CancellationToken cancellationToken)
        {
            try
            {
                var appointmentRepository = unitOfWork.GetRepository<Domain.Entities.Appointment>();
                return await appointmentRepository.GetByIdAsync(query.Id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while getting Appointment", ex);
            }
        }
    }
}
