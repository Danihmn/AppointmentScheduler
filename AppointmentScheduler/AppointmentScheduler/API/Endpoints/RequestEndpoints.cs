namespace AppointmentScheduler.API.Endpoints;

public static class RequestEndpoints
{
    public static WebApplication MapRequestEndpoints (this WebApplication app)
    {
        RouteGroupBuilder requestGroup = app.MapGroup("/api/requests").WithTags("Requests").RequireAuthorization();

        requestGroup.MapGet("/request", async (IQueryHandler<GetRequestsQuery, IEnumerable<RequestResponseDTO>> queryHandlerGetAllRequests, CancellationToken cancellationToken = default) =>
            await queryHandlerGetAllRequests.Handle(new GetRequestsQuery(), cancellationToken)).WithDescription("Lista todas as solicitações").RequireAuthorization();

        requestGroup.MapGet("/request/{id}", async (int id, IQueryHandler<GetRequestByIdQuery, RequestResponseDTO> queryHandlerGetRequestById, CancellationToken cancellationToken = default) =>
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);

            return await queryHandlerGetRequestById.Handle(new GetRequestByIdQuery(id), cancellationToken);
        }).WithDescription("Busca solicitação pelo Id").RequireAuthorization();

        requestGroup.MapPost("/request", async (CreateRequestCommand command, ICommandHandler<CreateRequestCommand, Request> commandHandlerCreateRequest, CancellationToken cancellationToken = default) =>
            await commandHandlerCreateRequest.Handle(command, cancellationToken)).WithDescription("Cria nova solicitação").RequireAuthorization(policy => policy.RequireRole("Admin"));

        return app;
    }
}