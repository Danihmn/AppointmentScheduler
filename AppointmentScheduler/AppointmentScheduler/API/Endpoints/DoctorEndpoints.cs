namespace AppointmentScheduler.API.Endpoints;

public static class DoctorEndpoints
{
    public static WebApplication MapDoctorEndpoints (this WebApplication app)
    {
        RouteGroupBuilder doctorGroup = app.MapGroup("/api/doctors").WithTags("Doctors");

        doctorGroup.MapGet("/doctor", async (IQueryHandler<GetDoctorsQuery, IEnumerable<DoctorResponseDTO>> queryHandlerGetAllDoctors, CancellationToken cancellationToken = default) =>
            await queryHandlerGetAllDoctors.Handle(new GetDoctorsQuery(), cancellationToken)).WithDescription("Lista todos os médicos").RequireAuthorization(policy => policy.RequireRole("Admin"));

        doctorGroup.MapGet("/doctor/{id}", async (int id, IQueryHandler<GetDoctorByIdQuery, DoctorResponseDTO> queryHandlerGetDoctorById, CancellationToken cancellationToken = default) =>
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);

            return await queryHandlerGetDoctorById.Handle(new GetDoctorByIdQuery(id), cancellationToken);
        }).WithDescription("Busca médico pelo Id").RequireAuthorization();

        doctorGroup.MapPost("/doctor", async (CreateDoctorCommand command, ICommandHandler<CreateDoctorCommand, Doctor> commandHandlerCreateDoctor, CancellationToken cancellationToken = default) =>
            await commandHandlerCreateDoctor.Handle(command, cancellationToken)).WithDescription("Cria novo médico").RequireAuthorization(policy => policy.RequireRole("Admin"));

        return app;
    }
}