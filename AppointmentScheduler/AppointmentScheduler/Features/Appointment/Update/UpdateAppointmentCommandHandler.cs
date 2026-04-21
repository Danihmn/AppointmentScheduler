namespace AppointmentScheduler.Features.Appointment.Update;

public class UpdateAppointmentCommandHandler (IUnitOfWork unitOfWork, IMapper mapper, INotificationService notificationService)
    : ICommandHandler<UpdateAppointmentCommand, ApiResponse<AppointmentResponseDTO>>
{
    public async Task<ApiResponse<AppointmentResponseDTO>> Handle
        (UpdateAppointmentCommand command, CancellationToken cancellationToken)
    {
        var appointment = await unitOfWork.AppointmentRepository.GetByIdAsync(command.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(AppointmentResponseDTO), command.Id);

        appointment.Date = command.Date;
        appointment.Status = command.Status;
        appointment.RequestId = command.RequestId;
        appointment.PatientId = command.PatientId;
        appointment.DoctorId = command.DoctorId;
        appointment.SpecialtyId = command.SpecialtyId;
        appointment.SecretaryId = command.SecretaryId;
        appointment.Notes = command.Notes;

        unitOfWork.AppointmentRepository.Update(appointment);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        var secretary = await unitOfWork.SecretaryRepository.GetByIdAsync(appointment.SecretaryId, cancellationToken);
        var patient = await unitOfWork.PatientRepository.GetByIdAsync(command.PatientId, cancellationToken);
        var doctor = await unitOfWork.DoctorRepository.GetByIdAsync(command.DoctorId, cancellationToken);

        if (secretary != null && patient != null && doctor != null)
            await notificationService
                .NotifyAppointmentUpdated(appointment.Id, secretary.Name, patient.Name, appointment.Date, doctor.Name);

        return ApiResponse<AppointmentResponseDTO>.Ok(mapper.Map<AppointmentResponseDTO>(appointment), "Consulta atualizada com sucesso.");

    }
}
