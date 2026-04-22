namespace AppointmentScheduler.Features.Appointment.Delete;

public class DeleteAppointmentCommandHandler
    (IUnitOfWork unitOfWork, IMapper mapper, INotificationService notificationService)
    : ICommandHandler<DeleteAppointmentCommand, ApiResponse<AppointmentResponseDTO>>
{
    public async Task<ApiResponse<AppointmentResponseDTO>> Handle
        (DeleteAppointmentCommand command, CancellationToken cancellationToken)
    {
        var appointment = await unitOfWork.AppointmentRepository.GetByIdWithDetailsAsync(command.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(AppointmentResponseDTO), command.Id);

        unitOfWork.AppointmentRepository.Remove(appointment);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        await notificationService.NotifyAppointmentDeleted(command.Id);

        return ApiResponse<AppointmentResponseDTO>.Ok(mapper.Map<AppointmentResponseDTO>(appointment), "Consulta removida com sucesso.");
    }
}
