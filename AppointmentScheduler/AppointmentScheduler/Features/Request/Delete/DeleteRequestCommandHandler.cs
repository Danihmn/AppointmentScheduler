namespace AppointmentScheduler.Features.Request.Delete;

public class DeleteRequestCommandHandler (IUnitOfWork unitOfWork, IMapper mapper)
    : ICommandHandler<DeleteRequestCommand, ApiResponse<RequestResponseDTO>>
{
    public async Task<ApiResponse<RequestResponseDTO>> Handle
        (DeleteRequestCommand command, CancellationToken cancellationToken)
    {
        var request = await unitOfWork.RequestRepository.GetByIdWithDetailsAsync(command.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(RequestResponseDTO), command.Id);

        unitOfWork.RequestRepository.Remove(request);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return ApiResponse<RequestResponseDTO>.Ok(mapper.Map<RequestResponseDTO>(request), "Solicitação removida com sucesso.");
    }
}
