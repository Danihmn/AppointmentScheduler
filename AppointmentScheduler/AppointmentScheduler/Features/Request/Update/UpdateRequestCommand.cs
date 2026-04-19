namespace AppointmentScheduler.Features.Request.Update;

public record UpdateRequestCommand (
    int Id,
    ERequestStatus Status,
    ERequestType Type,
    DateTime DesiredDate,
    string Description,
    string? Notes,
    EPriority Priority,
    int PatientId,
    int SpecialtyId,
    int? ProcessedBySecretaryId) : ICommand<ApiResponse<RequestResponseDTO>>;
