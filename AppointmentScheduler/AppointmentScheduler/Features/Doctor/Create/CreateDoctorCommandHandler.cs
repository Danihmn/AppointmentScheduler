namespace AppointmentScheduler.Features.Doctor.Create;

public class CreateDoctorCommandHandler
    (IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateDoctorCommand> validator)
    : ICommandHandler<CreateDoctorCommand, ApiResponse<DoctorResponseDTO>>
{
    public async Task<ApiResponse<DoctorResponseDTO>> Handle
        (CreateDoctorCommand command, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(command, cancellationToken);

        var doctorRepository = unitOfWork.DoctorRepository;
        var doctor = new Domain.Entities.Doctor
        {
            Name = command.Name,
            Crm = command.Crm,
            PhoneNumber = command.PhoneNumber,
            Email = command.Email,
            HiringDate = command.HiringDate,
            Active = command.Active,
            SpecialtyId = command.SpecialtyId
        };

        await doctorRepository.AddAsync(doctor, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return ApiResponse<DoctorResponseDTO>.Created(mapper.Map<DoctorResponseDTO>(doctor));
    }
}