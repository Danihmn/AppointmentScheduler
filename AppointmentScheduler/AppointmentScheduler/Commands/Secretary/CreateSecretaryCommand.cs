using AppointmentScheduler.Common;

namespace AppointmentScheduler.Commands.Secretary;

public record CreateSecretaryCommand(
    string Name,
    string Cpf,
    string PhoneNumber,
    string Email,
    DateTime HiringDate,
    bool Active) : ICommand<Domain.Entities.Secretary>;