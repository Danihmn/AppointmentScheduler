namespace AppointmentScheduler.Infrastructure.Tools;

public class RequestTools
    (
    IQueryHandler<GetRequestsQuery, ApiResponse<IEnumerable<RequestResponseDTO>>> getAllRequestsHandler,
    IQueryHandler<GetRequestByIdQuery, ApiResponse<RequestResponseDTO>> getRequestByIdQueryHandler,
    ICommandHandler<CreateRequestCommand, ApiResponse<RequestResponseDTO>> createRequestCommandHandler,
    ICommandHandler<UpdateRequestCommand, ApiResponse<RequestResponseDTO>> updateRequestCommandHandler
    )
{
    #region Queries
    [Description("Lists all requests. Use this when the user asks to list all the requests.")]
    public async Task<ApiResponse<IEnumerable<RequestResponseDTO>>> GetAllRequestsAsync (
        CancellationToken cancellationToken = default)
    => await getAllRequestsHandler.Handle(new GetRequestsQuery(), cancellationToken);

    [Description("Search request by Id. Use when the user asks for a specific request.")]
    public async Task<ApiResponse<RequestResponseDTO>> GetRequestByIdAsync (
        [Description("The Id of the request to search for.")] int id,
        CancellationToken cancellationToken = default)
    => await getRequestByIdQueryHandler.Handle(new GetRequestByIdQuery(id), cancellationToken);
    #endregion

    #region Commands
    [Description("Creates a new request. Use this when the user asks to register a request.")]
    public async Task<ApiResponse<RequestResponseDTO>> CreateRequestAsync (
        [Description("The details of the request to create.")] CreateRequestCommand command,
        CancellationToken cancellationToken = default)
    => await createRequestCommandHandler.Handle(command, cancellationToken);

    [Description("Updates an existing request. Use this when the user asks to update a request.")]
    public async Task<ApiResponse<RequestResponseDTO>> UpdateRequestAsync (
        [Description("The details of the request to update.")] UpdateRequestCommand command,
        CancellationToken cancellationToken = default)
    => await updateRequestCommandHandler.Handle(command, cancellationToken);
    #endregion
}
