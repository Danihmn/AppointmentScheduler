using AppointmentScheduler.Features.Doctor.Get;
using AppointmentScheduler.Features.Patient.Get;
using AppointmentScheduler.Features.Request.Get;
using AppointmentScheduler.Features.Secretary.Get;
using AppointmentScheduler.Features.Specialty.Get;

namespace AppointmentScheduler.Features.Appointment.Get
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
