using AppointmentScheduler.Application.Commands.Request;
using AppointmentScheduler.Infraestructure.Services.Contract;

namespace AppointmentScheduler.Endpoints
{
    public static class RequestEndpoints
    {
        public static Task<WebApplication> MapRequestEndpoints (this WebApplication app)
        {
            RouteGroupBuilder requestGroup = app.MapGroup("/api/requests").WithTags("Requests");

            requestGroup.MapGet("/request", async (IRequestService service) =>
                await service.GetRequestsAsync()).WithDescription("Lista todas as solicitações");

            requestGroup.MapGet("/request/{id}", async (IRequestService service, int id) =>
                await service.GetRequestByIdAsync(id)).WithDescription("Busca solicitação pelo Id");

            requestGroup.MapPost("/request",
                async (CreateRequestCommand command, IRequestService service) =>
                    await service.CreateRequestAsync(command.Status, command.Type, command.DesiredDate,
                        command.Description, command.Notes, command.Priority, command.PatientId, command.SpecialtyId,
                        command.ProcessedBySecretaryId)).WithDescription("Cria nova solicitação");

            return Task.FromResult(app);
        }
    }
}