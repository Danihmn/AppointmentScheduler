namespace AppointmentScheduler.Application.Commands.Request;

public class CreateRequestCommandHandler (IUnitOfWork unitOfWork)
    : ICommandHandler<CreateRequestCommand, Domain.Entities.Request>
{
    public async Task<Domain.Entities.Request> Handle (CreateRequestCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var requestRepository = unitOfWork.GetRepository<Domain.Entities.Request>();
            var request = new Domain.Entities.Request
            {
                Status = command.Status,
                Type = command.Type,
                DesiredDate = command.DesiredDate,
                Description = command.Description,
                Notes = command.Notes,
                Priority = command.Priority,
                PatientId = command.PatientId,
                SpecialtyId = command.SpecialtyId,
                ProcessedBySecretaryId = command.ProcessedBySecretaryId,
            };

            await requestRepository.AddAsync(request, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return request;
        }
        catch (Exception ex)
        {
            throw new Exception("Error while creating new Request", ex);
        }
    }
}