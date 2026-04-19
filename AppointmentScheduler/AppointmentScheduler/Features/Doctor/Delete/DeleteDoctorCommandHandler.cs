namespace AppointmentScheduler.Features.Doctor.Delete;

public class DeleteDoctorCommandHandler (IUnitOfWork unitOfWork, IMapper mapper)
    : ICommandHandler<DeleteDoctorCommand, ApiResponse<DoctorResponseDTO>>
{
    public async Task<ApiResponse<DoctorResponseDTO>> Handle
        (DeleteDoctorCommand command, CancellationToken cancellationToken)
    {
        var doctor = await unitOfWork.DoctorRepository.GetByIdWithDetailsAsync(command.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(DoctorResponseDTO), command.Id);

        unitOfWork.DoctorRepository.Remove(doctor);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return ApiResponse<DoctorResponseDTO>.Ok(mapper.Map<DoctorResponseDTO>(doctor), "Médico removido com sucesso.");
    }
}
