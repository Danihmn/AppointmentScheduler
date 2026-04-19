namespace AppointmentScheduler.Features.Doctor.Delete;

public record DeleteDoctorCommand (int Id) : ICommand<ApiResponse<DoctorResponseDTO>>;
