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
        var doctorRepository = unitOfWork.DoctorRepository;
        var secretaryRepository = unitOfWork.SecretaryRepository;
        var patientRepository = unitOfWork.PatientRepository;

        var request = await requestRepository.GetByIdAsync(command.RequestId, cancellationToken);
        var doctor = await doctorRepository.GetByIdAsync(command.DoctorId, cancellationToken);

        if (request is null)
            throw new NotFoundException($"Pedido não encontrado.", command.RequestId);

        if (doctor is not null)
            if (request.SpecialtyId != doctor.SpecialtyId)
                throw new BusinessRuleException("O médico selecionado não possui a especialidade requerida pelo pedido.");

        var appointment = new Domain.Entities.Appointment
        {
            Date = command.Date,
            Status = command.Status,
            RequestId = command.RequestId,
            PatientId = request.PatientId,
            DoctorId = command.DoctorId,
            SpecialtyId = request.SpecialtyId,
            SecretaryId = request.ProcessedBySecretaryId,
            Notes = request.Notes
        };

        await appointmentRepository.AddAsync(appointment, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        var secretary = await secretaryRepository.GetByIdAsync(request.ProcessedBySecretaryId, cancellationToken);
        var patient = await patientRepository.GetByIdAsync(request.PatientId, cancellationToken);

        if (secretary is not null && patient is not null && doctor is not null)
            await notificationService.NotifyAppointmentCreated(secretary.Name, patient.Name, command.Date, doctor.Name);

        return ApiResponse<AppointmentResponseDTO>.Created(mapper.Map<AppointmentResponseDTO>(appointment));
    }
}