namespace AppointmentScheduler.Features.Patient.Update;

public class UpdatePatientCommandHandler
    (IUnitOfWork unitOfWork, IMapper mapper, IValidator<UpdatePatientCommand> validator)
    : ICommandHandler<UpdatePatientCommand, ApiResponse<PatientResponseDTO>>
{
    public async Task<ApiResponse<PatientResponseDTO>> Handle
        (UpdatePatientCommand command, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(command, cancellationToken);

        var patient = await unitOfWork.PatientRepository.GetByIdAsync(command.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(PatientResponseDTO), command.Id);

        patient.Name = command.Name;
        patient.Cpf = command.Cpf;
        patient.PhoneNumber = command.PhoneNumber;
        patient.Email = command.Email;
        patient.Gender = command.Gender;
        patient.Notes = command.Notes;

        unitOfWork.PatientRepository.Update(patient);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return ApiResponse<PatientResponseDTO>.Ok(mapper.Map<PatientResponseDTO>(patient), "Paciente atualizado com sucesso.");
    }
}
