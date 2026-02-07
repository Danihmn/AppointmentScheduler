namespace AppointmentScheduler.Application.Data.DTO.Response
{
    public class DoctorResponseDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Crm { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public DateTime HiringDate { get; set; }
        public bool Active { get; set; }
        public SpecialtyResponseDTO? Specialty { get; set; }
        public ICollection<AppointmentResponseDTO> Appointments { get; set; } = [];
    }
}
