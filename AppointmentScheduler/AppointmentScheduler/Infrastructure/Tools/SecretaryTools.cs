namespace AppointmentScheduler.Infrastructure.Tools;

public class SecretaryTools
    (
    IQueryHandler<GetSecretariesQuery, ApiResponse<IEnumerable<SecretaryResponseDTO>>> getAllSecretariesHandler,
    IQueryHandler<GetSecretaryByIdQuery, ApiResponse<SecretaryResponseDTO>> getSecretaryByIdQueryHandler,
    ICommandHandler<CreateSecretaryCommand, ApiResponse<SecretaryResponseDTO>> createSecretaryCommandHandler,
    ICommandHandler<UpdateSecretaryCommand, ApiResponse<SecretaryResponseDTO>> updateSecretaryCommandHandler
    )
{
    #region Queries
    [Description("Lists all secretaries. Use this when the user asks to list all the secretaries.")]
    public async Task<ApiResponse<IEnumerable<SecretaryResponseDTO>>> GetAllSecretariesAsync (
        CancellationToken cancellationToken = default)
    => await getAllSecretariesHandler.Handle(new GetSecretariesQuery(), cancellationToken);

    [Description("Search secretary by Id. Use when the user asks for a specific secretary.")]
    public async Task<ApiResponse<SecretaryResponseDTO>> GetSecretaryByIdAsync (
        [Description("The Id of the secretary to search for.")] int id,
        CancellationToken cancellationToken = default)
    => await getSecretaryByIdQueryHandler.Handle(new GetSecretaryByIdQuery(id), cancellationToken);
    #endregion

    #region Commands
    [Description("Creates a new secretary. Use this when the user asks to register a secretary.")]
    public async Task<ApiResponse<SecretaryResponseDTO>> CreateSecretaryAsync (
        [Description("The details of the secretary to create.")] CreateSecretaryCommand command,
        CancellationToken cancellationToken = default)
    => await createSecretaryCommandHandler.Handle(command, cancellationToken);

    [Description("Updates an existing secretary. Use this when the user asks to update a secretary.")]
    public async Task<ApiResponse<SecretaryResponseDTO>> UpdateSecretaryAsync (
        [Description("The details of the secretary to update.")] UpdateSecretaryCommand command,
        CancellationToken cancellationToken = default)
    => await updateSecretaryCommandHandler.Handle(command, cancellationToken);
    #endregion
}
