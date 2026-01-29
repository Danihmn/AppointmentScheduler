using AppointmentScheduler.Commands.Doctor;
using AppointmentScheduler.Services.Contract;

namespace AppointmentScheduler.Endpoints
{
    public static class DoctorEndpoints
    {
        public static Task<WebApplication> MapDoctorEndpoints (this WebApplication app)
        {
            RouteGroupBuilder doctorGroup = app.MapGroup("/api/doctors").WithTags("Doctors");

            doctorGroup.MapGet("/doctor", async (IDoctorService service) =>
                await service.GetDoctorsAsync()).WithDescription("Lista todos os médicos");

            doctorGroup.MapGet("/doctor/{id}", async (IDoctorService service, int id) =>
                await service.GetDoctorByIdAsync(id)).WithDescription("Busca médico pelo Id");

            doctorGroup.MapPost("/doctor", async (CreateDoctorCommand command, IDoctorService service) =>
                await service.CreateDoctorAsync(command.Name, command.Crm, command.PhoneNumber, command.Email,
                    command.HiringDate, command.Active, command.SpecialtyId)).WithDescription("Cria novo médico");

            return Task.FromResult(app);
        }
    }
}