namespace AppointmentScheduler.Features.Appointment.Create;

public class ScheduleAppointmentCommandHandler
    (IUnitOfWork unitOfWork, IMapper mapper, INotificationService notificationService)
    : ICommandHandler<ScheduleAppointmentCommand, ApiResponse<AppointmentResponseDTO>>
{
    public async Task<ApiResponse<AppointmentResponseDTO>> Handle
        (ScheduleAppointmentCommand command, CancellationToken cancellationToken = default)
    {
        var requestRepository = unitOfWork.RequestRepository;
        var appointmentRepository = unitOfWork.AppointmentRepository;

        var request = await requestRepository.GetByIdAsync(command.RequestId, cancellationToken);

        var appointment = new Domain.Entities.Appointment
        {
            Date = command.Date,
            Status = command.Status,
            RequestId = command.RequestId,
            PatientId = request.PatientId,
            DoctorId = command.DoctorId,
            SpecialtyId = request.SpecialtyId,
            SecretaryId = request.ProcessedBySecretaryId ??= 0,
            Notes = request.Notes
        };

        await appointmentRepository.AddAsync(appointment, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        var secretary = await unitOfWork.SecretaryRepository.GetByIdAsync(request.ProcessedBySecretaryId ??= 0, cancellationToken);
        var patient = await unitOfWork.PatientRepository.GetByIdAsync(request.PatientId, cancellationToken);
        var doctor = await unitOfWork.DoctorRepository.GetByIdAsync(command.DoctorId, cancellationToken);

        if (secretary is not null && patient is not null && doctor is not null)
            await notificationService.NotifyAppointmentCreated(secretary.Name, patient.Name, command.Date, doctor.Name);

        return ApiResponse<AppointmentResponseDTO>.Created(mapper.Map<AppointmentResponseDTO>(appointment));
    }
}