namespace AppointmentScheduler.Features.Secretary.Authenticate
{
    public record AuthenticateSecretaryQuery (string Username, string Password) : IQuery<ApiResponse<LoginSecretaryResponseDTO>>;
}
