namespace AppointmentScheduler.Application.Queries.Appointment
{
    public class GetAppointmentsQueryHandler (IUnitOfWork unitOfWork, IMapper mapper)
        : IQueryHandler<GetAppointmentsQuery, IEnumerable<AppointmentResponseDTO>>
    {
        public async Task<IEnumerable<AppointmentResponseDTO>> Handle (
            GetAppointmentsQuery query,
            CancellationToken cancellationToken)
        {
            try
            {
                var appointmentRepository
                    = await unitOfWork.AppointmentRepository.GetAllWithDetailAsync(cancellationToken);

                return mapper.Map<IEnumerable<AppointmentResponseDTO>>(appointmentRepository);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while getting Appointments", ex);
            }
        }
    }
}
