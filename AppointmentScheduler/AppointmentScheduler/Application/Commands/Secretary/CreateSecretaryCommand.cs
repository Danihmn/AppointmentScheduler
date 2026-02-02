namespace AppointmentScheduler.Application.Commands.Secretary;

public record CreateSecretaryCommand (
    string Name,
    string Cpf,
    string PhoneNumber,
    string Email,
    DateTime HiringDate,
    bool Active) : ICommand<Domain.Entities.Secretary>;