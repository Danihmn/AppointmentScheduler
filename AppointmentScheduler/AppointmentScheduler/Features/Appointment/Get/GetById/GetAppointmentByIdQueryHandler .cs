namespace AppointmentScheduler.Features.Appointment.Get.GetById
{
    public class GetAppointmentByIdQueryHandler (IUnitOfWork unitOfWork, IMapper mapper)
        : IQueryHandler<GetAppointmentByIdQuery, ApiResponse<AppointmentResponseDTO>>
    {
        public async Task<ApiResponse<AppointmentResponseDTO>> Handle
            (GetAppointmentByIdQuery query, CancellationToken cancellationToken)
        {
            var appointmentRepository = await unitOfWork.AppointmentRepository.GetAllWithDetailAsync(cancellationToken);

            return appointmentRepository is null ?
                throw new NotFoundException(nameof(AppointmentResponseDTO), query.Id)
                : ApiResponse<AppointmentResponseDTO>.Ok(mapper.Map<AppointmentResponseDTO>(appointmentRepository));
        }
    }
}
