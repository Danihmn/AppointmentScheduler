namespace AppointmentScheduler.Application.Data.DTO.Response
{
    public class AppointmentResponseDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string? Status { get; set; }
        public string? Notes { get; set; }
        public RequestResponseDTO? Request { get; set; }
        public PatientResponseDTO? Patient { get; set; }
        public DoctorResponseDTO? Doctor { get; set; }
        public SpecialtyResponseDTO? Specialty { get; set; }
        public SecretaryResponseDTO? Secretary { get; set; }
    }
}
