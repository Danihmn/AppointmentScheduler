using AppointmentScheduler.Features.Common.CQRS;
using AppointmentScheduler.Features.Secretary.Create;
using AppointmentScheduler.Features.Secretary.Get;
using AppointmentScheduler.Features.Secretary.Get.GetAll;
using AppointmentScheduler.Features.Secretary.Get.GetById;

namespace AppointmentScheduler.Infraestructure.Services.Implementation;

public class SecretaryService
    (
        IQueryHandler<GetSecretariesQuery, IEnumerable<SecretaryResponseDTO>> queryHandlerGetAllSecretaries,
        IQueryHandler<GetSecretaryByIdQuery, SecretaryResponseDTO> queryHandlerGetSecretaryById,
        ICommandHandler<CreateSecretaryCommand, Secretary> commandHandlerCreateSecretary
    ) : ISecretaryService
{
    public async Task<IEnumerable<SecretaryResponseDTO>> GetSecretariesAsync (CancellationToken cancellationToken = default)
    {
        var query = new GetSecretariesQuery();
        return await queryHandlerGetAllSecretaries.Handle(query, cancellationToken);
    }

    public async Task<SecretaryResponseDTO> GetSecretaryByIdAsync (int id, CancellationToken cancellationToken = default)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);

        var query = new GetSecretaryByIdQuery(id);
        return await queryHandlerGetSecretaryById.Handle(query, cancellationToken);
    }

    public async Task<Secretary> CreateSecretaryAsync
    (
        string username,
        string password,
        string name,
        string cpf,
        string phoneNumber,
        string email,
        DateTime hiringDate,
        bool active,
        ERole role,
        CancellationToken cancellationToken = default
    )
    {
        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(cpf) || string.IsNullOrEmpty(phoneNumber) ||
            string.IsNullOrEmpty(email) || hiringDate == DateTime.MinValue)
            throw new Exception("Invalid data");

        var command =
            new CreateSecretaryCommand(username, password, name, cpf, phoneNumber, email, hiringDate, active, role);

        return await commandHandlerCreateSecretary.Handle(command, cancellationToken);
    }
}