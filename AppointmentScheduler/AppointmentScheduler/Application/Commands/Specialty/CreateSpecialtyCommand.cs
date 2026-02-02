namespace AppointmentScheduler.Application.Commands.Specialty;

public record CreateSpecialtyCommand (
    string Description,
    bool IsActive) : ICommand<Domain.Entities.Specialty>;