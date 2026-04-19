namespace AppointmentScheduler.Features.Patient.Delete;

public class DeletePatientCommandHandler (IUnitOfWork unitOfWork, IMapper mapper)
    : ICommandHandler<DeletePatientCommand, ApiResponse<PatientResponseDTO>>
{
    public async Task<ApiResponse<PatientResponseDTO>> Handle
        (DeletePatientCommand command, CancellationToken cancellationToken)
    {
        var patient = await unitOfWork.PatientRepository.GetByIdWithDetailsAsync(command.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(PatientResponseDTO), command.Id);

        unitOfWork.PatientRepository.Remove(patient);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return ApiResponse<PatientResponseDTO>.Ok(mapper.Map<PatientResponseDTO>(patient), "Paciente removido com sucesso.");
    }
}
