using AppointmentScheduler.Features.Common.CQRS;

namespace AppointmentScheduler.Features.Request.Create;

public record CreateRequestCommand (
    ERequestStatus Status,
    ERequestType Type,
    DateTime DesiredDate,
    string Description,
    string Notes,
    EPriority Priority,
    int PatientId,
    int SpecialtyId,
    int ProcessedBySecretaryId
) : ICommand<Domain.Entities.Request>;