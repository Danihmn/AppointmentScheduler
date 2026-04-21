namespace AppointmentScheduler.Features.Secretary.Create;

public record CreateSecretaryCommand (
    string Username,
    string Password,
    string Name,
    string Cpf,
    string PhoneNumber,
    string Email,
    DateTime HiringDate,
    bool IsActive,
    ERole Role) : ICommand<ApiResponse<SecretaryResponseDTO>>;