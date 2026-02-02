using AppointmentScheduler.Application.Queries.Specialty;

namespace AppointmentScheduler.Infraestructure.Services.Implementation;

public class SpecialtyService
    (
        IQueryHandler<GetSpecialtiesQuery, IEnumerable<Specialty>> queryHandlerGetAllSpecialties,
        IQueryHandler<GetSpecialtyByIdQuery, Specialty> queryHandlerGetSpecialtyById,
        ICommandHandler<CreateSpecialtyCommand, Specialty> commandHandlerCreateSpecialty
    ) : ISpecialtyService
{
    public async Task<IEnumerable<Specialty>> GetSpecialtiesAsync (CancellationToken cancellationToken = default)
    {
        var query = new GetSpecialtiesQuery();
        return await queryHandlerGetAllSpecialties.Handle(query, cancellationToken);
    }

    public async Task<Specialty> GetSpecialtyByIdAsync (int id, CancellationToken cancellationToken = default)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);

        var query = new GetSpecialtyByIdQuery(id);
        return await queryHandlerGetSpecialtyById.Handle(query, cancellationToken);
    }

    public async Task<Specialty> CreateSpecialtyAsync
    (
        string description,
        bool isActive,
        CancellationToken cancellationToken = default
    )
    {
        if (string.IsNullOrEmpty(description)) throw new Exception("Invalid data");

        var command = new CreateSpecialtyCommand(description, isActive);

        return await commandHandlerCreateSpecialty.Handle(command, cancellationToken);
    }
}