using AppointmentScheduler.Features.Common.CQRS;
using AppointmentScheduler.Infraestructure.Authentication.Services.Contract;
using AppointmentScheduler.Infraestructure.Persistence.UnifOfWork;

namespace AppointmentScheduler.Features.Secretary.Create;

public class CreateSecretaryCommandHandler (IUnitOfWork unitOfWork, IPasswordHasherService passwordHasherService)
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
                Username = command.Username,
                HashedPassword = passwordHasherService.Hash(command.Password),
                Name = command.Name,
                Cpf = command.Cpf,
                PhoneNumber = command.PhoneNumber,
                Email = command.Email,
                HiringDate = command.HiringDate,
                Active = command.Active,
                Role = command.Role,
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