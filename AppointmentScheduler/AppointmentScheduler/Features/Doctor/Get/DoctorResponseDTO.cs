namespace AppointmentScheduler.Features.Doctor.Get
{
    public class DoctorResponseDTO
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string Crm { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Email { get; set; }
        public required DateTime HiringDate { get; set; }
        public required bool Active { get; set; }
        public required int SpecialtyId { get; set; }
    }
}
