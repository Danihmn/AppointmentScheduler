namespace AppointmentScheduler.Features.Appointment.Update;

public record UpdateAppointmentCommand (
    int Id,
    DateTime Date,
    EAppointmentStatus Status,
    string? Notes,
    int RequestId,
    int DoctorId) : ICommand<ApiResponse<AppointmentResponseDTO>>;
