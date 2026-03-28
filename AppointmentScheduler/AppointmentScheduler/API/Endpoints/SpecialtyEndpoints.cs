namespace AppointmentScheduler.API.Endpoints;

public static class SpecialtyEndpoints
{
    public static WebApplication MapSpecialtyEndpoints (this WebApplication app)
    {
        RouteGroupBuilder specialtyGroup = app.MapGroup("/api/specialties").WithTags("Specialties").RequireAuthorization();

        specialtyGroup.MapGet("/specialty", async (IQueryHandler<GetSpecialtiesQuery, IEnumerable<SpecialtyResponseDTO>> queryHandlerGetAllSpecialties, CancellationToken cancellationToken = default) =>
            await queryHandlerGetAllSpecialties.Handle(new GetSpecialtiesQuery(), cancellationToken)).WithDescription("Lista todas as especialidades").RequireAuthorization(policy => policy.RequireRole("Admin"));

        specialtyGroup.MapGet("/specialty/{id}", async (int id, IQueryHandler<GetSpecialtyByIdQuery, SpecialtyResponseDTO> queryHandlerGetSpecialtyById, CancellationToken cancellationToken = default) =>
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);

            return await queryHandlerGetSpecialtyById.Handle(new GetSpecialtyByIdQuery(id), cancellationToken);
        }).WithDescription("Busca especialidade pelo Id").RequireAuthorization();

        specialtyGroup.MapPost("/specialty", async (CreateSpecialtyCommand command, ICommandHandler<CreateSpecialtyCommand, Specialty> commandHandlerCreateSpecialty, CancellationToken cancellationToken = default) =>
           await commandHandlerCreateSpecialty.Handle(command, cancellationToken)).WithDescription("Cria nova especialidade").RequireAuthorization(policy => policy.RequireRole("Admin"));

        return app;
    }
}