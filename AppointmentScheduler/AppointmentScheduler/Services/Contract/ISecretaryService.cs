using AppointmentScheduler.Domain.Entities;

namespace AppointmentScheduler.Services.Contract;

public interface ISecretaryService
{
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