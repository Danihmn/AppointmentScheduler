namespace AppointmentScheduler.Endpoints
{
    public static class SpecialtyEndpoints
    {
        public static Task<WebApplication> MapSpecialtyEndpoints (this WebApplication app)
        {
            RouteGroupBuilder specialtyGroup = app.MapGroup("/api/specialties").WithTags("Specialties");

            specialtyGroup.MapGet("/specialty", async (ISpecialtyService service) =>
                await service.GetSpecialtiesAsync()).WithDescription("Lista todas as especialidades");

            specialtyGroup.MapGet("/specialty/{id}", async (ISpecialtyService service, int id) =>
               await service.GetSecretaryByIdAsync(id)).WithDescription("Busca secretária pelo Id");

            specialtyGroup.MapPost("/specialty", async (CreateSpecialtyCommand command, ISpecialtyService service) =>
                await service.CreateSpecialtyAsync(command.Description, command.IsActive))
                .WithDescription("Cria nova especialidade");

            return Task.FromResult(app);
        }
    }
}
