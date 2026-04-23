namespace AppointmentScheduler.Features.Specialty.Delete;

public class DeleteSpecialtyCommandHandler (IUnitOfWork unitOfWork, IMapper mapper, INotificationService notificationService)
    : ICommandHandler<DeleteSpecialtyCommand, ApiResponse<SpecialtyResponseDTO>>
{
    public async Task<ApiResponse<SpecialtyResponseDTO>> Handle
        (DeleteSpecialtyCommand command, CancellationToken cancellationToken)
    {
        var specialty = await unitOfWork.SpecialtyRepository.GetByIdWithDetailsAsync(command.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(SpecialtyResponseDTO), command.Id);

        unitOfWork.SpecialtyRepository.Remove(specialty);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        await notificationService.NotifySpecialtyDeleted(specialty.Id, specialty.Description);

        return ApiResponse<SpecialtyResponseDTO>.Ok(mapper.Map<SpecialtyResponseDTO>(specialty), "Especialidade removida com sucesso.");
    }
}
