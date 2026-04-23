namespace AppointmentScheduler.Features.Request.Get
{
    public class RequestResponseDTO
    {
        public required int Id { get; set; }
        public required string Status { get; set; }
        public required string Type { get; set; }
        public required DateTime DesiredDate { get; set; }
        public required string Description { get; set; }
        public string? Notes { get; set; }
        public required string Priority { get; set; }
        public required int PatientId { get; set; }
        public required int SpecialtyId { get; set; }
        public required int ProcessedBySecretaryId { get; set; }
    }
}
