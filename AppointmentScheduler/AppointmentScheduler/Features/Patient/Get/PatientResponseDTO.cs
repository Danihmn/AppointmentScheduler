namespace AppointmentScheduler.Features.Patient.Get
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
    }
}
