namespace AppointmentScheduler.Features.Appointment.Update;

public class UpdateAppointmentCommandHandler (IUnitOfWork unitOfWork, IMapper mapper)
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

        return ApiResponse<AppointmentResponseDTO>.Ok(mapper.Map<AppointmentResponseDTO>(appointment), "Consulta atualizada com sucesso.");
    }
}
