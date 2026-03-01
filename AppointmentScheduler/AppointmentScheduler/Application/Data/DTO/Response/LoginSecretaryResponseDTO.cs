namespace AppointmentScheduler.Application.Data.DTO.Response
{
    public class LoginSecretaryResponseDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string? AccessToken { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
