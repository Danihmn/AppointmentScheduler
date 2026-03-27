using AppointmentScheduler.Features.Common.CQRS;

namespace AppointmentScheduler.Features.Specialty.Create;

public record CreateSpecialtyCommand (
    string Description,
    bool IsActive) : ICommand<Domain.Entities.Specialty>;