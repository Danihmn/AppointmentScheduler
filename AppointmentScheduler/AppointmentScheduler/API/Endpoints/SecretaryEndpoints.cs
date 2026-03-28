namespace AppointmentScheduler.API.Endpoints;

public static class SecretaryEndpoints
{
    public static WebApplication MapSecretaryEndpoints (this WebApplication app)
    {
        RouteGroupBuilder secretaryGroup = app.MapGroup("/api/secretaries").WithTags("Secretaries").RequireAuthorization();

        secretaryGroup.MapGet("/secretary", async (IQueryHandler<GetSecretariesQuery, IEnumerable<SecretaryResponseDTO>> queryHandlerGetAllSecretaries, CancellationToken cancellationToken = default) =>
        await queryHandlerGetAllSecretaries.Handle(new GetSecretariesQuery(), cancellationToken)).WithDescription("Lista todas as secretárias");

        secretaryGroup.MapGet("/secretary/{id}", async (int id, IQueryHandler<GetSecretaryByIdQuery, SecretaryResponseDTO> queryHandlerGetSecretaryById, CancellationToken cancellationToken = default) =>
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);

            return await queryHandlerGetSecretaryById.Handle(new GetSecretaryByIdQuery(id), cancellationToken);
        }).WithDescription("Busca secretária pelo Id");

        secretaryGroup.MapPost("/secretary", async (CreateSecretaryCommand command, ICommandHandler<CreateSecretaryCommand, Secretary> commandHandlerCreateSecretary, CancellationToken cancellationToken = default) =>
            await commandHandlerCreateSecretary.Handle(command, cancellationToken)).WithDescription("Cria nova secretária").RequireAuthorization(policy => policy.RequireRole("Admin"));

        return app;
    }
}
