using AppointmentScheduler.Application.Common;

namespace AppointmentScheduler.Application.Commands.Secretary;

public class CreateSecretaryCommandHandler (IUnitOfWork unitOfWork)
    : ICommandHandler<CreateSecretaryCommand, Domain.Entities.Secretary>
{
    public async Task<Domain.Entities.Secretary> Handle (CreateSecretaryCommand command,
        CancellationToken cancellationToken)
    {
        try
        {
            var secretaryRepository = unitOfWork.GetRepository<Domain.Entities.Secretary>();
            var secretary = new Domain.Entities.Secretary
            {
                Name = command.Name,
                Cpf = command.Cpf,
                PhoneNumber = command.PhoneNumber,
                Email = command.Email,
                HiringDate = command.HiringDate,
                Active = command.Active
            };

            await secretaryRepository.AddAsync(secretary, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return secretary;
        }
        catch (Exception ex)
        {
            throw new Exception("Error while creating new Secretary", ex);
        }
    }
}