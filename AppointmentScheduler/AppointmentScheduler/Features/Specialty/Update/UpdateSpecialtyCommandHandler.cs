namespace AppointmentScheduler.Features.Specialty.Update;

public class UpdateSpecialtyCommandHandler
    (IUnitOfWork unitOfWork, IMapper mapper, IValidator<UpdateSpecialtyCommand> validator)
    : ICommandHandler<UpdateSpecialtyCommand, ApiResponse<SpecialtyResponseDTO>>
{
    public async Task<ApiResponse<SpecialtyResponseDTO>> Handle
        (UpdateSpecialtyCommand command, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(command, cancellationToken);

        var specialty = await unitOfWork.SpecialtyRepository.GetByIdAsync(command.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(SpecialtyResponseDTO), command.Id);

        specialty.Description = command.Description;
        specialty.IsActive = command.IsActive;

        unitOfWork.SpecialtyRepository.Update(specialty);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return ApiResponse<SpecialtyResponseDTO>.Ok(mapper.Map<SpecialtyResponseDTO>(specialty), "Especialidade atualizada com sucesso.");
    }
}
