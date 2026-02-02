using AppointmentScheduler.Application.Common;

namespace AppointmentScheduler.Application.Commands.Specialty;

public class CreateSpecialtyCommandHandler (IUnitOfWork unitOfWork)
    : ICommandHandler<CreateSpecialtyCommand, Domain.Entities.Specialty>
{
    public async Task<Domain.Entities.Specialty> Handle (CreateSpecialtyCommand command,
        CancellationToken cancellationToken)
    {
        try
        {
            var specialtyRepository = unitOfWork.GetRepository<Domain.Entities.Specialty>();
            var specialty = new Domain.Entities.Specialty
            {
                Description = command.Description,
                IsActive = command.IsActive
            };

            await specialtyRepository.AddAsync(specialty, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return specialty;
        }
        catch (Exception ex)
        {
            throw new Exception("Error while creating new Specialty", ex);
        }
    }
}