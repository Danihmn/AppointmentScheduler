using AppointmentScheduler.Features.Secretary.Create;

namespace AppointmentScheduler.API.Endpoints;

public static class SecretaryEndpoints
{
    public static WebApplication MapSecretaryEndpoints (this WebApplication app)
    {
        RouteGroupBuilder secretaryGroup = app
            .MapGroup("/api/secretaries")
            .WithTags("Secretaries")
            .RequireAuthorization();

        secretaryGroup.MapGet("/secretary", async (ISecretaryService service) =>
            await service.GetSecretariesAsync()).WithDescription("Lista todas as secretárias");

        secretaryGroup.MapGet("/secretary/{id}", async (ISecretaryService service, int id) =>
           await service.GetSecretaryByIdAsync(id)).WithDescription("Busca secretária pelo Id");

        secretaryGroup.MapPost("/secretary", async (CreateSecretaryCommand command, ISecretaryService service) =>
            await service
            .CreateSecretaryAsync(
                command.Username,
                command.Password,
                command.Name,
                command.Cpf,
                command.PhoneNumber,
                command.Email,
                command.HiringDate,
                command.Active,
                command.Role))
            .WithDescription("Cria nova secretária")
            .RequireAuthorization(policy => policy.RequireRole("Admin"));

        return app;
    }
}
