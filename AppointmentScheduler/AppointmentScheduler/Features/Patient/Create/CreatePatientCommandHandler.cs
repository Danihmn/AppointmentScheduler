namespace AppointmentScheduler.Features.Patient.Create;

public class CreatePatientCommandHandler
    (IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreatePatientCommand> validator)
    : ICommandHandler<CreatePatientCommand, ApiResponse<PatientResponseDTO>>
{
    public async Task<ApiResponse<PatientResponseDTO>> Handle (CreatePatientCommand command, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(command, cancellationToken);

        var patientRepository = unitOfWork.PatientRepository;
        var patient = new Domain.Entities.Patient
        {
            Name = command.Name,
            Cpf = command.Cpf,
            PhoneNumber = command.PhoneNumber,
            Email = command.Email,
            Gender = command.Gender,
            Notes = command.Notes,
        };

        await patientRepository.AddAsync(patient, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return ApiResponse<PatientResponseDTO>.Created(mapper.Map<PatientResponseDTO>(patient));
    }
}