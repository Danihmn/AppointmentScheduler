using AppointmentScheduler.Common;
using AppointmentScheduler.Domain.Enums;

namespace AppointmentScheduler.Commands.Request;

public record CreateRequestCommand(
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