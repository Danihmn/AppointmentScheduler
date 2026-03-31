namespace AppointmentScheduler.API.Endpoints;

public static class PatientEndpoints
{
    public static WebApplication MapPatientEndpoints (this WebApplication app)
    {
        RouteGroupBuilder patientGroup = app.MapGroup("/api/patients").WithTags("Patients");

        patientGroup.MapGet("/patient", async (IQueryHandler<GetPatientsQuery, ApiResponse<IEnumerable<PatientResponseDTO>>> queryHandlerGetAllPatients, CancellationToken cancellationToken = default) =>
            TypedResults.Ok(await queryHandlerGetAllPatients.Handle(new GetPatientsQuery(), cancellationToken))).WithDescription("Lista todos os pacientes").RequireAuthorization(policy => policy.RequireRole("Admin"));

        patientGroup.MapGet("/patient/{id}", async (int id, IQueryHandler<GetPatientByIdQuery, ApiResponse<PatientResponseDTO>> queryHandlerGetPatientById, CancellationToken cancellationToken = default) =>
            TypedResults.Ok(await queryHandlerGetPatientById.Handle(new GetPatientByIdQuery(id), cancellationToken))).WithDescription("Busca paciente pelo Id").RequireAuthorization();

        patientGroup.MapPost("/patient", async (CreatePatientCommand command, ICommandHandler<CreatePatientCommand, ApiResponse<PatientResponseDTO>> commandHandlerCreatePatients, CancellationToken cancellationToken = default) =>
            TypedResults.Created($"/api/patients/patient/{command}", await commandHandlerCreatePatients.Handle(command, cancellationToken))).WithDescription("Cria novo paciente").RequireAuthorization(policy => policy.RequireRole("Admin"));

        return app;
    }
}