namespace AppointmentScheduler.Application.Commands.Secretary;

public record CreateSecretaryCommand (
    string Username,
    string Password,
    string Name,
    string Cpf,
    string PhoneNumber,
    string Email,
    DateTime HiringDate,
    bool Active,
    ERole Role) : ICommand<Domain.Entities.Secretary>;