namespace AppointmentScheduler.Features.Appointment.Delete;

public class DeleteAppointmentCommandHandler (IUnitOfWork unitOfWork, IMapper mapper)
    : ICommandHandler<DeleteAppointmentCommand, ApiResponse<AppointmentResponseDTO>>
{
    public async Task<ApiResponse<AppointmentResponseDTO>> Handle
        (DeleteAppointmentCommand command, CancellationToken cancellationToken)
    {
        var appointment = await unitOfWork.AppointmentRepository.GetByIdWithDetailsAsync(command.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(AppointmentResponseDTO), command.Id);

        unitOfWork.AppointmentRepository.Remove(appointment);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return ApiResponse<AppointmentResponseDTO>.Ok(mapper.Map<AppointmentResponseDTO>(appointment), "Consulta removida com sucesso.");
    }
}
