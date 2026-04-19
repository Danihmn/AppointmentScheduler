namespace AppointmentScheduler.Features.Specialty.Delete;

public record DeleteSpecialtyCommand (int Id) : ICommand<ApiResponse<SpecialtyResponseDTO>>;
