namespace AppointmentScheduler.Infraestructure.Services.Contract;

public interface ISecretaryService
{
    Task<IEnumerable<SecretaryResponseDTO>> GetSecretariesAsync (CancellationToken cancellationToken = default);
    Task<SecretaryResponseDTO> GetSecretaryByIdAsync (int id, CancellationToken cancellationToken = default);
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