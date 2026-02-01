namespace AppointmentScheduler.Endpoints
{
    public static class SpecialtyEndpoints
    {
        public static Task<WebApplication> MapSpecialtyEndpoints (this WebApplication app)
        {
            RouteGroupBuilder specialtyGroup = app.MapGroup("/api/specialties").WithTags("Specialties");

            specialtyGroup.MapPost("/specialty", async (CreateSpecialtyCommand command, ISpecialtyService service) =>
                await service.CreateSpecialtyAsync(command.Description, command.IsActive));

            return Task.FromResult(app);
        }
    }
}
