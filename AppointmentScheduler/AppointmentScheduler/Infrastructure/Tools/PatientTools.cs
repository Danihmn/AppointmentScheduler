namespace AppointmentScheduler.Infrastructure.Tools;

public class PatientTools
    (
    IQueryHandler<GetPatientsQuery, ApiResponse<IEnumerable<PatientResponseDTO>>> getAllPatientsHandler,
    IQueryHandler<GetPatientByIdQuery, ApiResponse<PatientResponseDTO>> getPatientByIdQueryHandler,
    ICommandHandler<CreatePatientCommand, ApiResponse<PatientResponseDTO>> createPatientCommandHandler,
    ICommandHandler<UpdatePatientCommand, ApiResponse<PatientResponseDTO>> updatePatientCommandHandler
    )
{
    #region Queries
    [Description("Lists all patients. Use this when the user asks to list all the patients.")]
    public async Task<ApiResponse<IEnumerable<PatientResponseDTO>>> GetAllPatientsAsync (
        CancellationToken cancellationToken = default)
    => await getAllPatientsHandler.Handle(new GetPatientsQuery(), cancellationToken);

    [Description("Search patient by Id. Use when the user asks for a specific patient.")]
    public async Task<ApiResponse<PatientResponseDTO>> GetPatientByIdAsync (
        [Description("The Id of the patient to search for.")] int id,
        CancellationToken cancellationToken = default)
    => await getPatientByIdQueryHandler.Handle(new GetPatientByIdQuery(id), cancellationToken);
    #endregion

    #region Commands
    [Description("Creates a new patient. Use this when the user asks to register a patient.")]
    public async Task<ApiResponse<PatientResponseDTO>> CreatePatientAsync (
        [Description("The details of the patient to create.")] CreatePatientCommand command,
        CancellationToken cancellationToken = default)
    => await createPatientCommandHandler.Handle(command, cancellationToken);

    [Description("Updates an existing patient. Use this when the user asks to update a patient.")]
    public async Task<ApiResponse<PatientResponseDTO>> UpdatePatientAsync (
        [Description("The details of the patient to update.")] UpdatePatientCommand command,
        CancellationToken cancellationToken = default)
    => await updatePatientCommandHandler.Handle(command, cancellationToken);
    #endregion
}
