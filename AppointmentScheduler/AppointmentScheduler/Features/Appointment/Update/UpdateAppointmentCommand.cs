namespace AppointmentScheduler.Features.Appointment.Update;

public record UpdateAppointmentCommand (
    int Id,
    DateTime Date,
    EAppointmentStatus Status,
    int RequestId,
    int PatientId,
    int DoctorId,
    int SpecialtyId,
    int SecretaryId,
    string? Notes = null) : ICommand<ApiResponse<AppointmentResponseDTO>>;
