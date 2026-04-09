namespace AppointmentScheduler.Infrastructure.Authentication.Services.Contract
{
    public interface ITokenService
    {
        public string Generate (LoginSecretaryResponseDTO secretary, IEnumerable<Claim>? additionalClaims = null);
    }
}
