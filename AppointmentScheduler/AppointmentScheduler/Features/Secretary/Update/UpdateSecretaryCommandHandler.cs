namespace AppointmentScheduler.Features.Secretary.Update;

public class UpdateSecretaryCommandHandler (IUnitOfWork unitOfWork, IPasswordHasherService passwordHasherService, IMapper mapper)
    : ICommandHandler<UpdateSecretaryCommand, ApiResponse<SecretaryResponseDTO>>
{
    public async Task<ApiResponse<SecretaryResponseDTO>> Handle
        (UpdateSecretaryCommand command, CancellationToken cancellationToken)
    {
        var secretary = await unitOfWork.SecretaryRepository.GetByIdAsync(command.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(SecretaryResponseDTO), command.Id);

        secretary.Username = command.Username;
        secretary.Name = command.Name;
        secretary.Cpf = command.Cpf;
        secretary.PhoneNumber = command.PhoneNumber;
        secretary.Email = command.Email;
        secretary.HiringDate = command.HiringDate;
        secretary.Active = command.Active;
        secretary.Role = command.Role;

        if (!string.IsNullOrWhiteSpace(command.Password))
            secretary.HashedPassword = passwordHasherService.Hash(command.Password);

        unitOfWork.SecretaryRepository.Update(secretary);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return ApiResponse<SecretaryResponseDTO>.Ok(mapper.Map<SecretaryResponseDTO>(secretary), "Secretária atualizada com sucesso.");
    }
}
