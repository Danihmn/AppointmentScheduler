using AppointmentScheduler.Commands.Doctor;
using AppointmentScheduler.Services.Contract;

namespace AppointmentScheduler.Endpoints
{
    public static class DoctorEndpoints
    {
        public static Task<WebApplication> MapDoctorEndpoints (this WebApplication app)
        {
            RouteGroupBuilder doctorGroup = app.MapGroup("/api/doctors").WithTags("Doctors");

            doctorGroup.MapPost("/doctor", async (CreateDoctorCommand command, IDoctorService service) =>
                await service.CreateDoctorAsync(command.Name, command.Crm, command.PhoneNumber, command.Email,
                    command.HiringDate, command.Active, command.SpecialtyId));

            return Task.FromResult(app);
        }
    }
}