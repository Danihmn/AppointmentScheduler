namespace AppointmentScheduler.Features.Appointment.Update;

public class UpdateAppointmentCommandHandler
    (IUnitOfWork unitOfWork, IMapper mapper, INotificationService notificationService, IValidator<UpdateAppointmentCommand> validator)
    : ICommandHandler<UpdateAppointmentCommand, ApiResponse<AppointmentResponseDTO>>
{
    public async Task<ApiResponse<AppointmentResponseDTO>> Handle
        (UpdateAppointmentCommand command, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(command, cancellationToken);

        var appointment = await unitOfWork.AppointmentRepository.GetByIdAsync(command.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(AppointmentResponseDTO), command.Id);

        appointment.Date = command.Date;
        appointment.Status = command.Status;
        appointment.RequestId = command.RequestId;
        appointment.DoctorId = command.DoctorId;
        appointment.Notes = command.Notes;

        unitOfWork.AppointmentRepository.Update(appointment);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        var request = await unitOfWork.RequestRepository.GetByIdAsync(command.RequestId, cancellationToken)
            ?? throw new NotFoundException(nameof(RequestResponseDTO), command.RequestId);
        var patient = await unitOfWork.PatientRepository.GetByIdAsync(request.PatientId, cancellationToken);
        var doctor = await unitOfWork.DoctorRepository.GetByIdAsync(command.DoctorId, cancellationToken);

        if (request != null && doctor != null && patient != null)
            await notificationService
                .NotifyAppointmentUpdated(appointment.Id, patient.Name, appointment.Date, doctor.Name);

        return ApiResponse<AppointmentResponseDTO>.Ok(mapper.Map<AppointmentResponseDTO>(appointment), "Consulta atualizada com sucesso.");
    }
}
