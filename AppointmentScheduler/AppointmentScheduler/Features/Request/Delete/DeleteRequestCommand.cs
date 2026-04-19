namespace AppointmentScheduler.Features.Request.Delete;

public record DeleteRequestCommand (int Id) : ICommand<ApiResponse<RequestResponseDTO>>;
