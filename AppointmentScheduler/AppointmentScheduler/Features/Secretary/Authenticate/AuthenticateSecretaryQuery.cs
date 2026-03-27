using AppointmentScheduler.Features.Common.CQRS;

namespace AppointmentScheduler.Features.Secretary.Authenticate
{
    public record AuthenticateSecretaryQuery (string Username, string Password) : IQuery<LoginSecretaryResponseDTO>;
}
