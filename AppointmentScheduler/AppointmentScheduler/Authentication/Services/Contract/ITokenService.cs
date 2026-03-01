namespace AppointmentScheduler.Authentication.Services.Contract
{
    public interface ITokenService
    {
        public string Generate (LoginSecretaryResponseDTO secretary);
    }
}
