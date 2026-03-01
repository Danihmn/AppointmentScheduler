namespace AppointmentScheduler.Authentication.Services.Implementation
{
    public class PasswordHasherService : IPasswordHasherService
    {
        public string Hash (string password) =>
            Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(password))).ToLower();

        public bool Verify (string password, string hashedPassword) => Hash(password) == hashedPassword;
    }
}
