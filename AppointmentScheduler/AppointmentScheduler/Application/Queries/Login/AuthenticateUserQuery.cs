namespace AppointmentScheduler.Application.Queries.Login
{
    public record AuthenticateUserQuery (string Username, string Password) : IQuery<LoginSecretaryResponseDTO>;
}
