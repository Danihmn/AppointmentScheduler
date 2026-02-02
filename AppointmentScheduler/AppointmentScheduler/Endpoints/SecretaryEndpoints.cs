using AppointmentScheduler.Application.Commands.Secretary;
using AppointmentScheduler.Infraestructure.Services.Contract;

namespace AppointmentScheduler.Endpoints
{
    public static class SecretaryEndpoints
    {
        public static Task<WebApplication> MapSecretaryEndpoints (this WebApplication app)
        {
            RouteGroupBuilder secretaryGroup = app.MapGroup("/api/secretaries").WithTags("Secretaries");

            secretaryGroup.MapGet("/secretary", async (ISecretaryService service) =>
                await service.GetSecretariesAsync()).WithDescription("Lista todas as secretárias");

            secretaryGroup.MapGet("/secretary/{id}", async (ISecretaryService service, int id) =>
               await service.GetSecretaryByIdAsync(id)).WithDescription("Busca secretária pelo Id");

            secretaryGroup.MapPost("/secretary", async (CreateSecretaryCommand command, ISecretaryService service) =>
                await service.CreateSecretaryAsync(command.Name, command.Cpf, command.PhoneNumber, command.Email,
                    command.HiringDate, command.Active)).WithDescription("Cria nova secretária");

            return Task.FromResult(app);
        }
    }
}
