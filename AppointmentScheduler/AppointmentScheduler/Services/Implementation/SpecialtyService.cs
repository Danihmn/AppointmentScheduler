namespace AppointmentScheduler.Services.Implementation;

public class SpecialtyService (ICommandHandler<CreateSpecialtyCommand, Specialty> commandHandler) : ISpecialtyService
{
    public async Task<Specialty> CreateSpecialtyAsync
    (
        string description,
        bool isActive,
        CancellationToken cancellationToken = default
    )
    {
        if (string.IsNullOrEmpty(description)) throw new Exception("Invalid data");

        var command = new CreateSpecialtyCommand(description, isActive);

        return await commandHandler.Handle(command, cancellationToken);
    }
}