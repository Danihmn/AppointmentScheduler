namespace AppointmentScheduler.Features.Specialty.Get
{
    public class SpecialtyResponseDTO
    {
        public required int Id { get; set; }
        public required string Description { get; set; }
        public required bool IsActive { get; set; }
    }
}
