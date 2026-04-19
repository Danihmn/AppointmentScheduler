namespace AppointmentScheduler.Features.Secretary.Delete;

public class DeleteSecretaryCommandHandler (IUnitOfWork unitOfWork, IMapper mapper)
    : ICommandHandler<DeleteSecretaryCommand, ApiResponse<SecretaryResponseDTO>>
{
    public async Task<ApiResponse<SecretaryResponseDTO>> Handle
        (DeleteSecretaryCommand command, CancellationToken cancellationToken)
    {
        var secretary = await unitOfWork.SecretaryRepository.GetByIdWithDetailsAsync(command.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(SecretaryResponseDTO), command.Id);

        unitOfWork.SecretaryRepository.Remove(secretary);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return ApiResponse<SecretaryResponseDTO>.Ok(mapper.Map<SecretaryResponseDTO>(secretary), "Secretária removida com sucesso.");
    }
}
