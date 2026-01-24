using AppointmentScheduler.Commands.Secretary;
using AppointmentScheduler.Common;
using AppointmentScheduler.Domain.Entities;
using AppointmentScheduler.Services.Contract;

namespace AppointmentScheduler.Services.Implementation;

public class SecretaryService(ICommandHandler<CreateSecretaryCommand, Secretary> commandHandler) : ISecretaryService
{
    public async Task<Secretary> CreateSecretaryAsync
    (
        string name,
        string cpf,
        string phoneNumber,
        string email,
        DateTime hiringDate,
        bool active,
        CancellationToken cancellationToken = default
    )
    {
        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(cpf) || string.IsNullOrEmpty(phoneNumber) ||
            string.IsNullOrEmpty(email) || hiringDate == DateTime.MinValue)
            throw new Exception("Invalid data");

        var command = new CreateSecretaryCommand(name, cpf, phoneNumber, email, hiringDate, active);
        
        return await commandHandler.Handle(command, cancellationToken);
    }
}