namespace AppointmentScheduler.Infrastructure.Tools;

public class SpecialtyTools
    (
    IQueryHandler<GetSpecialtiesQuery, ApiResponse<IEnumerable<SpecialtyResponseDTO>>> getAllSpecialtiesHandler,
    IQueryHandler<GetSpecialtyByIdQuery, ApiResponse<SpecialtyResponseDTO>> getSpecialtyByIdQueryHandler,
    ICommandHandler<CreateSpecialtyCommand, ApiResponse<SpecialtyResponseDTO>> createSpecialtyCommandHandler,
    ICommandHandler<UpdateSpecialtyCommand, ApiResponse<SpecialtyResponseDTO>> updateSpecialtyCommandHandler
    )
{
    #region Queries
    [Description("Lists all specialties. Use this when the user asks to list all the specialties.")]
    public async Task<ApiResponse<IEnumerable<SpecialtyResponseDTO>>> GetAllSpecialtiesAsync (
        CancellationToken cancellationToken = default)
    => await getAllSpecialtiesHandler.Handle(new GetSpecialtiesQuery(), cancellationToken);

    [Description("Search specialty by Id. Use when the user asks for a specific specialty.")]
    public async Task<ApiResponse<SpecialtyResponseDTO>> GetSpecialtyByIdAsync (
        [Description("The Id of the specialty to search for.")] int id,
        CancellationToken cancellationToken = default)
    => await getSpecialtyByIdQueryHandler.Handle(new GetSpecialtyByIdQuery(id), cancellationToken);
    #endregion

    #region Commands
    [Description("Creates a new specialty. Use this when the user asks to create a specialty.")]
    public async Task<ApiResponse<SpecialtyResponseDTO>> CreateSpecialtyAsync (
        [Description("The details of the specialty to create.")] CreateSpecialtyCommand command,
        CancellationToken cancellationToken = default)
    => await createSpecialtyCommandHandler.Handle(command, cancellationToken);

    [Description("Updates an existing specialty. Use this when the user asks to update a specialty.")]
    public async Task<ApiResponse<SpecialtyResponseDTO>> UpdateSpecialtyAsync (
        [Description("The details of the specialty to update.")] UpdateSpecialtyCommand command,
        CancellationToken cancellationToken = default)
    => await updateSpecialtyCommandHandler.Handle(command, cancellationToken);
    #endregion
}