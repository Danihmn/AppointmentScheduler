namespace AppointmentScheduler.Application.Data.DTO.Response
{
    public class SpecialtyResponseDTO
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public ICollection<RequestResponseDTO> Requests { get; set; } = [];
        public ICollection<DoctorResponseDTO> Doctors { get; set; } = [];
    }
}
