using AppointmentScheduler.Commands.Patient;
using AppointmentScheduler.Services.Contract;

namespace AppointmentScheduler.Endpoints;

public static class PatientEndpoints
{
    public static Task<WebApplication> MapPatientEndpoints (this WebApplication app)
    {
        RouteGroupBuilder patientGroup = app.MapGroup("/api/patients").WithTags("Patients");

        patientGroup.MapGet("/patient", async (IPatientService service) =>
                await service.GetPatientsAsync()).WithDescription("Lista todos os pacientes");

        patientGroup.MapPost("/patient",
            async (CreatePatientCommand command, IPatientService service) =>
                await service.CreatePatientAsync(command.Name, command.Cpf, command.PhoneNumber, command.Email,
                    command.Gender, command.Notes)).WithDescription("Cria novo paciente");

        return Task.FromResult(app);
    }
}