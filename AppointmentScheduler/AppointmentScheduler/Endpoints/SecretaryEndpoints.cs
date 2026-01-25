using AppointmentScheduler.Commands.Secretary;
using AppointmentScheduler.Services.Contract;

namespace AppointmentScheduler.Endpoints
{
    public static class SecretaryEndpoints
    {
        public static Task<WebApplication> MapSecretaryEndpoints (this WebApplication app)
        {
            RouteGroupBuilder secretaryGroup = app.MapGroup("/api/secretaries").WithTags("Secretaries");

            secretaryGroup.MapPost("/secretary", async (CreateSecretaryCommand command, ISecretaryService service) =>
                await service.CreateSecretaryAsync(command.Name, command.Cpf, command.PhoneNumber, command.Email,
                    command.HiringDate, command.Active));

            return Task.FromResult(app);
        }
    }
}
