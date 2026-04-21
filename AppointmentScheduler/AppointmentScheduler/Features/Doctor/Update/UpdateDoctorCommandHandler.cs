namespace AppointmentScheduler.Features.Doctor.Update;

public class UpdateDoctorCommandHandler
    (IUnitOfWork unitOfWork, IMapper mapper, IValidator<UpdateDoctorCommand> validator)
    : ICommandHandler<UpdateDoctorCommand, ApiResponse<DoctorResponseDTO>>
{
    public async Task<ApiResponse<DoctorResponseDTO>> Handle
        (UpdateDoctorCommand command, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(command, cancellationToken);

        var doctor = await unitOfWork.DoctorRepository.GetByIdAsync(command.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(DoctorResponseDTO), command.Id);

        doctor.Name = command.Name;
        doctor.Crm = command.Crm;
        doctor.PhoneNumber = command.PhoneNumber;
        doctor.Email = command.Email;
        doctor.HiringDate = command.HiringDate;
        doctor.Active = command.Active;
        doctor.SpecialtyId = command.SpecialtyId;

        unitOfWork.DoctorRepository.Update(doctor);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return ApiResponse<DoctorResponseDTO>.Ok(mapper.Map<DoctorResponseDTO>(doctor), "Médico atualizado com sucesso.");
    }
}
