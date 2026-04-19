namespace AppointmentScheduler.API.Endpoints;

public static class SecretaryEndpoints
{
    public static WebApplication MapSecretaryEndpoints (this WebApplication app)
    {
        RouteGroupBuilder secretaryGroup = app.MapGroup("/api/secretaries").WithTags("Secretaries").RequireAuthorization();

        secretaryGroup.MapGet("/secretary", async (IQueryHandler<GetSecretariesQuery, ApiResponse<IEnumerable<SecretaryResponseDTO>>> queryHandlerGetAllSecretaries, CancellationToken cancellationToken = default) =>
            TypedResults.Ok(await queryHandlerGetAllSecretaries.Handle(new GetSecretariesQuery(), cancellationToken))).WithDescription("Lista todas as secretárias");

        secretaryGroup.MapGet("/secretary/{id}", async (int id, IQueryHandler<GetSecretaryByIdQuery, ApiResponse<SecretaryResponseDTO>> queryHandlerGetSecretaryById, CancellationToken cancellationToken = default) =>
            TypedResults.Ok(await queryHandlerGetSecretaryById.Handle(new GetSecretaryByIdQuery(id), cancellationToken))).WithDescription("Busca secretária pelo Id");

        secretaryGroup.MapPost("/secretary", async (CreateSecretaryCommand command, ICommandHandler<CreateSecretaryCommand, ApiResponse<SecretaryResponseDTO>> commandHandlerCreateSecretary, CancellationToken cancellationToken = default) =>
            TypedResults.Created($"/api/secretaries/secretary/{command}", await commandHandlerCreateSecretary.Handle(command, cancellationToken))).WithDescription("Cria nova secretária").RequireAuthorization(policy => policy.RequireRole("Admin"));

        secretaryGroup.MapPut("/secretary/{id}", async (int id, UpdateSecretaryCommand command, ICommandHandler<UpdateSecretaryCommand, ApiResponse<SecretaryResponseDTO>> commandHandlerUpdateSecretary, CancellationToken cancellationToken = default) =>
            TypedResults.Ok(await commandHandlerUpdateSecretary.Handle(command with { Id = id }, cancellationToken))).WithDescription("Atualiza secretária existente").RequireAuthorization(policy => policy.RequireRole("Admin"));

        secretaryGroup.MapDelete("/secretary/{id}", async (int id, ICommandHandler<DeleteSecretaryCommand, ApiResponse<SecretaryResponseDTO>> commandHandlerDeleteSecretary, CancellationToken cancellationToken = default) =>
            TypedResults.Ok(await commandHandlerDeleteSecretary.Handle(new DeleteSecretaryCommand(id), cancellationToken))).WithDescription("Remove secretária").RequireAuthorization(policy => policy.RequireRole("Admin"));

        return app;
    }
}
