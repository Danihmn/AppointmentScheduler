namespace AppointmentScheduler.API.Endpoints;

public static class RequestEndpoints
{
    public static WebApplication MapRequestEndpoints (this WebApplication app)
    {
        RouteGroupBuilder requestGroup = app.MapGroup("/api/requests").WithTags("Requests").RequireAuthorization();

        requestGroup.MapGet("/request", async (IQueryHandler<GetRequestsQuery, ApiResponse<IEnumerable<RequestResponseDTO>>> queryHandlerGetAllRequests, CancellationToken cancellationToken = default) =>
            TypedResults.Ok(await queryHandlerGetAllRequests.Handle(new GetRequestsQuery(), cancellationToken))).WithDescription("Lista todas as solicitações").RequireAuthorization();

        requestGroup.MapGet("/request/{id}", async (int id, IQueryHandler<GetRequestByIdQuery, ApiResponse<RequestResponseDTO>> queryHandlerGetRequestById, CancellationToken cancellationToken = default) =>
            TypedResults.Ok(await queryHandlerGetRequestById.Handle(new GetRequestByIdQuery(id), cancellationToken))).WithDescription("Busca solicitação pelo Id").RequireAuthorization();

        requestGroup.MapPost("/request", async (CreateRequestCommand command, ICommandHandler<CreateRequestCommand, ApiResponse<RequestResponseDTO>> commandHandlerCreateRequest, CancellationToken cancellationToken = default) =>
            TypedResults.Created($"/api/requests/request/{command}", await commandHandlerCreateRequest.Handle(command, cancellationToken))).WithDescription("Cria nova solicitação").RequireAuthorization(policy => policy.RequireRole("Admin"));

        requestGroup.MapPut("/request", async (UpdateRequestCommand command, ICommandHandler<UpdateRequestCommand, ApiResponse<RequestResponseDTO>> commandHandlerUpdateRequest, CancellationToken cancellationToken = default) =>
            TypedResults.Ok(await commandHandlerUpdateRequest.Handle(command, cancellationToken))).WithDescription("Atualiza solicitação existente").RequireAuthorization(policy => policy.RequireRole("Admin"));

        requestGroup.MapDelete("/request/{id}", async (int id, ICommandHandler<DeleteRequestCommand, ApiResponse<RequestResponseDTO>> commandHandlerDeleteRequest, CancellationToken cancellationToken = default) =>
            TypedResults.Ok(await commandHandlerDeleteRequest.Handle(new DeleteRequestCommand(id), cancellationToken))).WithDescription("Remove solicitação").RequireAuthorization(policy => policy.RequireRole("Admin"));

        return app;
    }
}