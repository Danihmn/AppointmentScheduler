namespace AppointmentScheduler.Features.Appointment.Create;

public record ScheduleAppointmentCommand (
    DateTime Date,
    string? Notes,
    int RequestId,
    int DoctorId) : ICommand<ApiResponse<AppointmentResponseDTO>>;