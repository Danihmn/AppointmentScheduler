namespace AppointmentScheduler.Features.Request.Create;

public class CreateRequestCommandHandler (IUnitOfWork unitOfWork, IMapper mapper)
    : ICommandHandler<CreateRequestCommand, ApiResponse<RequestResponseDTO>>
{
    public async Task<ApiResponse<RequestResponseDTO>> Handle
        (CreateRequestCommand command, CancellationToken cancellationToken)
    {
        var requestRepository = unitOfWork.RequestRepository;
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

        return ApiResponse<RequestResponseDTO>.Created(mapper.Map<RequestResponseDTO>(request));
    }
}