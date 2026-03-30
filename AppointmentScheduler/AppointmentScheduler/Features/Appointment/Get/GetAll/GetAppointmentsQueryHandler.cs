namespace AppointmentScheduler.Features.Appointment.Get.GetAll
{
    public class GetAppointmentsQueryHandler (IUnitOfWork unitOfWork, IMapper mapper)
        : IQueryHandler<GetAppointmentsQuery, ApiResponse<IEnumerable<AppointmentResponseDTO>>>
    {
        public async Task<ApiResponse<IEnumerable<AppointmentResponseDTO>>> Handle
            (GetAppointmentsQuery query, CancellationToken cancellationToken)
        {
            var appointmentRepository = await unitOfWork.AppointmentRepository.GetAllWithDetailAsync(cancellationToken);

            return appointmentRepository is null ?
                throw new NotFoundException(nameof(AppointmentResponseDTO), null)
                : ApiResponse<IEnumerable<AppointmentResponseDTO>>.Ok(mapper.Map<IEnumerable<AppointmentResponseDTO>>(appointmentRepository));
        }
    }
}
