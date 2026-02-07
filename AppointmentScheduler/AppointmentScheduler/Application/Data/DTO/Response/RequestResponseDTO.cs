namespace AppointmentScheduler.Application.Data.DTO.Response
{
    public class RequestResponseDTO
    {
        public int Id { get; set; }
        public string? Status { get; set; }
        public string? Type { get; set; }
        public DateTime DesiredDate { get; set; }
        public string? Description { get; set; }
        public string? Notes { get; set; }
        public string? Priority { get; set; }
        public Patient? Patient { get; set; }
        public SpecialtyResponseDTO? Specialty { get; set; }
        public SecretaryResponseDTO? ProcessedBySecretary { get; set; }
        public AppointmentResponseDTO? ResultingAppointment { get; set; }
    }
}
