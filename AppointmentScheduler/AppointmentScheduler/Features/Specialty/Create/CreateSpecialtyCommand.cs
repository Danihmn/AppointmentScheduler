namespace AppointmentScheduler.Features.Specialty.Create;

public record CreateSpecialtyCommand (string Description, bool IsActive)
    : ICommand<ApiResponse<SpecialtyResponseDTO>>;