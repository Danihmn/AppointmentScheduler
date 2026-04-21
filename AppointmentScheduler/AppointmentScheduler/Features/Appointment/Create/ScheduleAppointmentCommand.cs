namespace AppointmentScheduler.Features.Appointment.Create;

public record ScheduleAppointmentCommand (
    DateTime Date,
    EAppointmentStatus Status,
    int RequestId,
    int DoctorId) : ICommand<ApiResponse<AppointmentResponseDTO>>;