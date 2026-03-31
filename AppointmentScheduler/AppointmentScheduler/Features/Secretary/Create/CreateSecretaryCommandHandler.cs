namespace AppointmentScheduler.Features.Secretary.Create;

public class CreateSecretaryCommandHandler (IUnitOfWork unitOfWork, IPasswordHasherService passwordHasherService, IMapper mapper)
    : ICommandHandler<CreateSecretaryCommand, ApiResponse<SecretaryResponseDTO>>
{
    public async Task<ApiResponse<SecretaryResponseDTO>> Handle
        (CreateSecretaryCommand command, CancellationToken cancellationToken)
    {
        var secretaryRepository = unitOfWork.SecretaryRepository;
        var secretary = new Domain.Entities.Secretary
        {
            Username = command.Username,
            HashedPassword = passwordHasherService.Hash(command.Password),
            Name = command.Name,
            Cpf = command.Cpf,
            PhoneNumber = command.PhoneNumber,
            Email = command.Email,
            HiringDate = command.HiringDate,
            Active = command.Active,
            Role = command.Role,
        };

        await secretaryRepository.AddAsync(secretary, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return ApiResponse<SecretaryResponseDTO>.Created(mapper.Map<SecretaryResponseDTO>(secretary));
    }
}