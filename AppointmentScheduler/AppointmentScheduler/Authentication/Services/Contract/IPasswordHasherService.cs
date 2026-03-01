namespace AppointmentScheduler.Authentication.Services.Contract
{
    public interface IPasswordHasherService
    {
        public string Hash (string password);
        public bool Verify (string password, string hashedPassword);
    }
}
