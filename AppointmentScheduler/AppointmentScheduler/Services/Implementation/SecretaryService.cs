namespace AppointmentScheduler.Services.Implementation;

public class SecretaryService
    (
        IQueryHandler<GetSecretariesQuery, IEnumerable<Secretary>> queryHandlerGetAllSecretaries,
        ICommandHandler<CreateSecretaryCommand, Secretary> commandHandlerCreateSecretary
    ) : ISecretaryService
{
    public async Task<IEnumerable<Secretary>> GetSecretariesAsync (CancellationToken cancellationToken = default)
    {
        var query = new GetSecretariesQuery();
        return await queryHandlerGetAllSecretaries.Handle(query, cancellationToken);
    }

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

        return await commandHandlerCreateSecretary.Handle(command, cancellationToken);
    }
}