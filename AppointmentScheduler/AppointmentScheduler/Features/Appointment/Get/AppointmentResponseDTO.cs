namespace AppointmentScheduler.Features.Appointment.Get
{
    public class AppointmentResponseDTO
    {
        public required int Id { get; set; }
        public required DateTime Date { get; set; }
        public required string Status { get; set; }
        public string? Notes { get; set; }
        public required int RequestId { get; set; }
        public required int DoctorId { get; set; }
    }
}
