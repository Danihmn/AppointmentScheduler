namespace AppointmentScheduler.Features.Specialty.Delete;

public class DeleteSpecialtyCommandHandler (IUnitOfWork unitOfWork, IMapper mapper)
    : ICommandHandler<DeleteSpecialtyCommand, ApiResponse<SpecialtyResponseDTO>>
{
    public async Task<ApiResponse<SpecialtyResponseDTO>> Handle
        (DeleteSpecialtyCommand command, CancellationToken cancellationToken)
    {
        var specialty = await unitOfWork.SpecialtyRepository.GetByIdWithDetailsAsync(command.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(SpecialtyResponseDTO), command.Id);

        unitOfWork.SpecialtyRepository.Remove(specialty);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return ApiResponse<SpecialtyResponseDTO>.Ok(mapper.Map<SpecialtyResponseDTO>(specialty), "Especialidade removida com sucesso.");
    }
}
