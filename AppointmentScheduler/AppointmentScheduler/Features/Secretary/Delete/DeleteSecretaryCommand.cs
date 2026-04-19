namespace AppointmentScheduler.Features.Secretary.Delete;

public record DeleteSecretaryCommand (int Id) : ICommand<ApiResponse<SecretaryResponseDTO>>;
