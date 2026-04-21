namespace AppointmentScheduler.Features.Appointment.Create;

public record ScheduleAppointmentCommand (
    DateTime Date,
    EStatus Status,
    int RequestId,
    int DoctorId) : ICommand<ApiResponse<AppointmentResponseDTO>>;