namespace AppointmentScheduler.Features.Patient.Get
{
    public class PatientResponseDTO
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string Cpf { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Email { get; set; }
        public required string Gender { get; set; }
        public string? Notes { get; set; }
    }
}
