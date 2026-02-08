namespace AppointmentScheduler.Application.Queries.Appointment
{
    public class GetAppointmentByIdQueryHandler (IUnitOfWork unitOfWork, IMapper mapper)
        : IQueryHandler<GetAppointmentByIdQuery, AppointmentResponseDTO>
    {
        public async Task<AppointmentResponseDTO> Handle
            (
                GetAppointmentByIdQuery query,
                CancellationToken cancellationToken
            )
        {
            try
            {
                var appointmentRepository
                    = await unitOfWork.AppointmentRepository.GetByIdWithDetailsAsync(query.Id, cancellationToken);

                return appointmentRepository == null ? throw new Exception()
                    : mapper.Map<AppointmentResponseDTO>(appointmentRepository);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while getting Appointment", ex);
            }
        }
    }
}
