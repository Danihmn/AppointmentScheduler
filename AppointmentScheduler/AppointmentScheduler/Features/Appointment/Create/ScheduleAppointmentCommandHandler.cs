namespace AppointmentScheduler.Features.Appointment.Create;

public class
    ScheduleAppointmentCommandHandler (IUnitOfWork unitOfWork, IMapper mapper)
    : ICommandHandler<ScheduleAppointmentCommand, ApiResponse<AppointmentResponseDTO>>
{
    public async Task<ApiResponse<AppointmentResponseDTO>> Handle
        (ScheduleAppointmentCommand command, CancellationToken cancellationToken = default)
    {
        var appointmentRepository = unitOfWork.AppointmentRepository;
        var appointment = new Domain.Entities.Appointment
        {
            Date = command.Date,
            Status = command.Status,
            RequestId = command.RequestId,
            PatientId = command.PatientId,
            DoctorId = command.DoctorId,
            SpecialtyId = command.SpecialtyId,
            SecretaryId = command.SecretaryId,
            Notes = command.Notes
        };

        await appointmentRepository.AddAsync(appointment, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return ApiResponse<AppointmentResponseDTO>.Created(mapper.Map<AppointmentResponseDTO>(appointment));
    }
}