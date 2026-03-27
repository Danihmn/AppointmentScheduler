using AppointmentScheduler.Features.Secretary.Authenticate;

namespace AppointmentScheduler.Infraestructure.Authentication.Services.Contract
{
    public interface ITokenService
    {
        public string Generate (LoginSecretaryResponseDTO secretary, IEnumerable<Claim>? additionalClaims = null);
    }
}
