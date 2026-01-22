using AppointmentScheduler.Commands.Specialty;
using AppointmentScheduler.Common;
using AppointmentScheduler.Domain.Entities;
using AppointmentScheduler.Services.Contract;

namespace AppointmentScheduler.Services.Implementation;

public class SpecialtyService(ICommandHandler<CreateSpecialtyCommand, Specialty> commandHandler) : ISpecialtyService
{
    public async Task<Specialty> AddSpecialty(string description, bool isActive,
        CancellationToken cancellationToken = default)
    {
        if (description == null) throw new Exception("Invalid data");

        var command = new CreateSpecialtyCommand(description, isActive);
        return await commandHandler.Handle(command, cancellationToken);
    }
}