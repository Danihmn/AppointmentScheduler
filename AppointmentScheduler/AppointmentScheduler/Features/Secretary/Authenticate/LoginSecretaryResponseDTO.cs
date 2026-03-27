namespace AppointmentScheduler.Features.Secretary.Authenticate
{
    public class LoginSecretaryResponseDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string? AccessToken { get; set; }
        public string? Role { get; set; }
    }
}
