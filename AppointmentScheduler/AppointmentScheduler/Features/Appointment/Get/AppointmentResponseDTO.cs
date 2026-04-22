namespace AppointmentScheduler.Features.Appointment.Get
{
    public class AppointmentResponseDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string? Status { get; set; }
        public string? Notes { get; set; }
        public RequestResponseDTO? Request { get; set; }
        public DoctorResponseDTO? Doctor { get; set; }
    }
}
