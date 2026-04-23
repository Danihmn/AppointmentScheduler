namespace AppointmentScheduler.API.Endpoints;

public static class DoctorEndpoints
{
    public static WebApplication MapDoctorEndpoints (this WebApplication app)
    {
        RouteGroupBuilder doctorGroup = app.MapGroup("/api/doctors").WithTags("Doctors");

        doctorGroup.MapGet("/doctor", async (IQueryHandler<GetDoctorsQuery, ApiResponse<IEnumerable<DoctorResponseDTO>>> queryHandlerGetAllDoctors, CancellationToken cancellationToken = default) =>
            TypedResults.Ok(await queryHandlerGetAllDoctors.Handle(new GetDoctorsQuery(), cancellationToken))).WithDescription("Lista todos os médicos").RequireAuthorization(policy => policy.RequireRole("Admin"));

        doctorGroup.MapGet("/doctor/{id}", async (int id, IQueryHandler<GetDoctorByIdQuery, ApiResponse<DoctorResponseDTO>> queryHandlerGetDoctorById, CancellationToken cancellationToken = default) =>
            TypedResults.Ok(await queryHandlerGetDoctorById.Handle(new GetDoctorByIdQuery(id), cancellationToken))).WithDescription("Busca médico pelo Id").RequireAuthorization();

        doctorGroup.MapPost("/doctor", async (CreateDoctorCommand command, ICommandHandler<CreateDoctorCommand, ApiResponse<DoctorResponseDTO>> commandHandlerCreateDoctor, CancellationToken cancellationToken = default) =>
            TypedResults.Created($"/api/doctors/doctor/{command}", await commandHandlerCreateDoctor.Handle(command, cancellationToken))).WithDescription("Cria novo médico").RequireAuthorization(policy => policy.RequireRole("Admin"));

        doctorGroup.MapPut("/doctor", async (UpdateDoctorCommand command, ICommandHandler<UpdateDoctorCommand, ApiResponse<DoctorResponseDTO>> commandHandlerUpdateDoctor, CancellationToken cancellationToken = default) =>
            TypedResults.Ok(await commandHandlerUpdateDoctor.Handle(command, cancellationToken))).WithDescription("Atualiza médico existente").RequireAuthorization(policy => policy.RequireRole("Admin"));

        doctorGroup.MapDelete("/doctor/{id}", async (int id, ICommandHandler<DeleteDoctorCommand, ApiResponse<DoctorResponseDTO>> commandHandlerDeleteDoctor, CancellationToken cancellationToken = default) =>
            TypedResults.Ok(await commandHandlerDeleteDoctor.Handle(new DeleteDoctorCommand(id), cancellationToken))).WithDescription("Remove médico").RequireAuthorization(policy => policy.RequireRole("Admin"));

        return app;
    }
}