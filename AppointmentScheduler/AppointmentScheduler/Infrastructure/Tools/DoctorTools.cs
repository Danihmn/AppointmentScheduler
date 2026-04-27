namespace AppointmentScheduler.Infrastructure.Tools;

public class DoctorTools
    (
    IQueryHandler<GetDoctorsQuery, ApiResponse<IEnumerable<DoctorResponseDTO>>> getAllDoctorsHandler,
    IQueryHandler<GetDoctorByIdQuery, ApiResponse<DoctorResponseDTO>> getDoctorByIdQueryHandler,
    ICommandHandler<CreateDoctorCommand, ApiResponse<DoctorResponseDTO>> createDoctorCommandHandler,
    ICommandHandler<UpdateDoctorCommand, ApiResponse<DoctorResponseDTO>> updateDoctorCommandHandler
    )
{
    #region Queries
    [Description("Lists all doctors. Use this when the user asks to list all the doctors.")]
    public async Task<ApiResponse<IEnumerable<DoctorResponseDTO>>> GetAllDoctorsAsync (
        CancellationToken cancellationToken = default)
    => await getAllDoctorsHandler.Handle(new GetDoctorsQuery(), cancellationToken);

    [Description("Search doctor by Id. Use when the user asks for a specific doctor.")]
    public async Task<ApiResponse<DoctorResponseDTO>> GetDoctorByIdAsync (
        [Description("The Id of the doctor to search for.")] int id,
        CancellationToken cancellationToken = default)
    => await getDoctorByIdQueryHandler.Handle(new GetDoctorByIdQuery(id), cancellationToken);
    #endregion

    #region Commands
    [Description("Creates a new doctor. Use this when the user asks to register a doctor.")]
    public async Task<ApiResponse<DoctorResponseDTO>> CreateDoctorAsync (
        [Description("The details of the doctor to create.")] CreateDoctorCommand command,
        CancellationToken cancellationToken = default)
    => await createDoctorCommandHandler.Handle(command, cancellationToken);

    [Description("Updates an existing doctor. Use this when the user asks to update a doctor.")]
    public async Task<ApiResponse<DoctorResponseDTO>> UpdateDoctorAsync (
        [Description("The details of the doctor to update.")] UpdateDoctorCommand command,
        CancellationToken cancellationToken = default)
    => await updateDoctorCommandHandler.Handle(command, cancellationToken);
    #endregion
}
