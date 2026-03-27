using AppointmentScheduler.Features.Secretary.Authenticate;

namespace AppointmentScheduler.Infraestructure.Services.Contract
{
    public interface ILoginService
    {
        Task<LoginSecretaryResponseDTO> AuthenticateUserAsync
            (string username, string password, CancellationToken cancellationToken = default);
    }
}
