namespace AppointmentScheduler.API.Endpoints;

public static class SpecialtyEndpoints
{
    public static WebApplication MapSpecialtyEndpoints (this WebApplication app)
    {
        RouteGroupBuilder specialtyGroup = app.MapGroup("/api/specialties").WithTags("Specialties");

        specialtyGroup.MapGet("/specialty", async (IQueryHandler<GetSpecialtiesQuery, ApiResponse<IEnumerable<SpecialtyResponseDTO>>> queryHandlerGetAllSpecialties, CancellationToken cancellationToken = default) =>
            TypedResults.Ok(await queryHandlerGetAllSpecialties.Handle(new GetSpecialtiesQuery(), cancellationToken))).WithDescription("Lista todas as especialidades").RequireAuthorization(policy => policy.RequireRole("Admin"));

        specialtyGroup.MapGet("/specialty/{id}", async (int id, IQueryHandler<GetSpecialtyByIdQuery, ApiResponse<SpecialtyResponseDTO>> queryHandlerGetSpecialtyById, CancellationToken cancellationToken = default) =>
            TypedResults.Ok(await queryHandlerGetSpecialtyById.Handle(new GetSpecialtyByIdQuery(id), cancellationToken))).WithDescription("Busca especialidade pelo Id").RequireAuthorization();

        specialtyGroup.MapPost("/specialty", async (CreateSpecialtyCommand command, ICommandHandler<CreateSpecialtyCommand, ApiResponse<SpecialtyResponseDTO>> commandHandlerCreateSpecialty, CancellationToken cancellationToken = default) =>
            TypedResults.Created($"/api/specialties/specialty/{command}", await commandHandlerCreateSpecialty.Handle(command, cancellationToken))).WithDescription("Cria nova especialidade").RequireAuthorization(policy => policy.RequireRole("Admin"));

        specialtyGroup.MapPut("/specialty", async (UpdateSpecialtyCommand command, ICommandHandler<UpdateSpecialtyCommand, ApiResponse<SpecialtyResponseDTO>> commandHandlerUpdateSpecialty, CancellationToken cancellationToken = default) =>
            TypedResults.Ok(await commandHandlerUpdateSpecialty.Handle(command, cancellationToken))).WithDescription("Atualiza especialidade existente").RequireAuthorization(policy => policy.RequireRole("Admin"));

        specialtyGroup.MapDelete("/specialty/{id}", async (int id, ICommandHandler<DeleteSpecialtyCommand, ApiResponse<SpecialtyResponseDTO>> commandHandlerDeleteSpecialty, CancellationToken cancellationToken = default) =>
            TypedResults.Ok(await commandHandlerDeleteSpecialty.Handle(new DeleteSpecialtyCommand(id), cancellationToken))).WithDescription("Remove especialidade").RequireAuthorization(policy => policy.RequireRole("Admin"));

        return app;
    }
}