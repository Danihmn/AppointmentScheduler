namespace AppointmentScheduler.Features.Secretary.Update;

public record UpdateSecretaryCommand (
    int Id,
    string Username,
    string Name,
    string Cpf,
    string PhoneNumber,
    string Email,
    DateTime HiringDate,
    bool Active,
    ERole Role,
    string? Password = null) : ICommand<ApiResponse<SecretaryResponseDTO>>;
