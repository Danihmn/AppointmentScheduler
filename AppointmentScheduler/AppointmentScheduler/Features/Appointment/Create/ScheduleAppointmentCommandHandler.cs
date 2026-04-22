namespace AppointmentScheduler.Features.Appointment.Create;

public class ScheduleAppointmentCommandHandler
    (IUnitOfWork unitOfWork, IMapper mapper, INotificationService notificationService, IValidator<ScheduleAppointmentCommand> validator)
    : ICommandHandler<ScheduleAppointmentCommand, ApiResponse<AppointmentResponseDTO>>
{
    public async Task<ApiResponse<AppointmentResponseDTO>> Handle
        (ScheduleAppointmentCommand command, CancellationToken cancellationToken = default)
    {
        await validator.ValidateAndThrowAsync(command, cancellationToken);

        var requestRepository = unitOfWork.RequestRepository;
        var appointmentRepository = unitOfWork.AppointmentRepository;
        var doctorRepository = unitOfWork.DoctorRepository;
        var patientRepository = unitOfWork.PatientRepository;

        var request = await requestRepository.GetByIdAsync(command.RequestId, cancellationToken);
        var doctor = await doctorRepository.GetByIdAsync(command.DoctorId, cancellationToken);

        if (request is null)
            throw new NotFoundException($"Pedido não encontrado.", command.RequestId);

        if (request.Status != ERequestStatus.Approved)
            throw new BusinessRuleException("A solicitação deve estar aprovada para agendar uma consulta.");

        if (doctor is not null)
            if (request.SpecialtyId != doctor.SpecialtyId)
                throw new BusinessRuleException("O médico selecionado não possui a especialidade requerida pelo pedido.");

        var appointment = new Domain.Entities.Appointment
        {
            Date = command.Date,
            Status = command.Status,
            RequestId = command.RequestId,
            DoctorId = command.DoctorId,
            Notes = request.Notes
        };

        await appointmentRepository.AddAsync(appointment, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        var patient = await patientRepository.GetByIdAsync(request.PatientId, cancellationToken);

        if (patient is not null && doctor is not null)
            await notificationService.NotifyAppointmentCreated(patient.Name, command.Date, doctor.Name);

        return ApiResponse<AppointmentResponseDTO>.Created(mapper.Map<AppointmentResponseDTO>(appointment));
    }
}