namespace AppointmentScheduler.Features.Appointment.Delete;

public record DeleteAppointmentCommand (int Id) : ICommand<ApiResponse<AppointmentResponseDTO>>;
