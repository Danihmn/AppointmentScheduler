namespace AppointmentScheduler.Features.Request.Update;

public class UpdateRequestCommandHandler (IUnitOfWork unitOfWork, IMapper mapper)
    : ICommandHandler<UpdateRequestCommand, ApiResponse<RequestResponseDTO>>
{
    public async Task<ApiResponse<RequestResponseDTO>> Handle
        (UpdateRequestCommand command, CancellationToken cancellationToken)
    {
        var request = await unitOfWork.RequestRepository.GetByIdAsync(command.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(RequestResponseDTO), command.Id);

        request.Status = command.Status;
        request.Type = command.Type;
        request.DesiredDate = command.DesiredDate;
        request.Description = command.Description;
        request.Notes = command.Notes;
        request.Priority = command.Priority;
        request.PatientId = command.PatientId;
        request.SpecialtyId = command.SpecialtyId;
        request.ProcessedBySecretaryId = command.ProcessedBySecretaryId;

        unitOfWork.RequestRepository.Update(request);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return ApiResponse<RequestResponseDTO>.Ok(mapper.Map<RequestResponseDTO>(request), "Solicitação atualizada com sucesso.");
    }
}
