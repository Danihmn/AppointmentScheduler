namespace AppointmentScheduler.Services.Contract;

public interface ISecretaryService
{
    Task<IEnumerable<Secretary>> GetSecretariesAsync (CancellationToken cancellationToken = default);
    Task<Secretary> CreateSecretaryAsync
    (
        string name,
        string cpf,
        string phoneNumber,
        string email,
        DateTime hiringDate,
        bool active,
        CancellationToken cancellationToken = default
    );
}