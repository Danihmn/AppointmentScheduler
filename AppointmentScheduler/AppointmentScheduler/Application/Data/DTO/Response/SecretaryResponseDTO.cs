namespace AppointmentScheduler.Application.Data.DTO.Response
{
    public class SecretaryResponseDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Cpf { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public DateTime HiringDate { get; set; }
        public bool Active { get; set; }
        public ICollection<AppointmentResponseDTO> Appointments { get; set; } = [];
        public ICollection<RequestResponseDTO> ProcessedRequests { get; set; } = [];
    }
}
