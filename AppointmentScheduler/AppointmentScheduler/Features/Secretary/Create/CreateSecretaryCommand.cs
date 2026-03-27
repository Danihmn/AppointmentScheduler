using AppointmentScheduler.Features.Common.CQRS;

namespace AppointmentScheduler.Features.Secretary.Create;

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