namespace AppointmentScheduler.Application.Data.DTO.Response
{
    public class PatientResponseDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Cpf { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Gender { get; set; }
        public string? Notes { get; set; }
        public ICollection<Appointment> Appointments { get; set; } = [];
        public ICollection<Request> Requests { get; set; } = [];
    }
}
