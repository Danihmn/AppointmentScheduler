using AppointmentScheduler.Commands.Request;
using AppointmentScheduler.Services.Contract;

namespace AppointmentScheduler.Endpoints
{
    public static class RequestEndpoints
    {
        public static Task<WebApplication> MapRequestEndpoints (this WebApplication app)
        {
            RouteGroupBuilder requestGroup = app.MapGroup("/api/requests").WithTags("Requests");

            requestGroup.MapPost("/request",
                async (CreateRequestCommand command, IRequestService service) =>
                    await service.CreateRequestAsync(command.Status, command.Type, command.DesiredDate, command.Description,
                        command.Notes, command.Priority, command.PatientId, command.SpecialtyId, command.ProcessedBySecretaryId));

            return Task.FromResult(app);
        }
    }
}
