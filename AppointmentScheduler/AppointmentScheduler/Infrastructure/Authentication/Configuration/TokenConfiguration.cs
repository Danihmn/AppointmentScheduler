namespace AppointmentScheduler.Infrastructure.Authentication.Configuration
{
    public class TokenConfiguration
    {
        public static string PrivateKey =>
            Environment.GetEnvironmentVariable("JWT_PRIVATE_KEY")
            ?? throw new InvalidOperationException("JWT_PRIVATE_KEY não configurada");
    }
}
