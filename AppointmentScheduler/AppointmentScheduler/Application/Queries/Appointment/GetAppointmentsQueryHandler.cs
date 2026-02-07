namespace AppointmentScheduler.Application.Queries.Appointment
{
    public class GetAppointmentsQueryHandler (IUnitOfWork unitOfWork)
        : IQueryHandler<GetAppointmentsQuery, IEnumerable<AppointmentResponseDTO>>
    {
        public async Task<IEnumerable<AppointmentResponseDTO>> Handle (
            GetAppointmentsQuery query,
            CancellationToken cancellationToken)
        {
            try
            {
                var appointmentRepository = unitOfWork.GetRepository<Domain.Entities.Appointment>();
                var entity = await appointmentRepository.GetAllAsync(cancellationToken);

                return entity.Adapt<IEnumerable<AppointmentResponseDTO>>();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while getting Appointments", ex);
            }
        }
    }
}
