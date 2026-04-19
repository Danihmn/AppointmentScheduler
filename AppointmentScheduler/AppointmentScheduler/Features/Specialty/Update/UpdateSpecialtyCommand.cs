namespace AppointmentScheduler.Features.Specialty.Update;

public record UpdateSpecialtyCommand (
    int Id,
    string Description,
    bool IsActive) : ICommand<ApiResponse<SpecialtyResponseDTO>>;
