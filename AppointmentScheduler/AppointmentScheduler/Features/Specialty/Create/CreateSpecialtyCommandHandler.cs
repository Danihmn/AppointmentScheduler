namespace AppointmentScheduler.Features.Specialty.Create;

public class CreateSpecialtyCommandHandler (IUnitOfWork unitOfWork, IMapper mapper)
    : ICommandHandler<CreateSpecialtyCommand, ApiResponse<SpecialtyResponseDTO>>
{
    public async Task<ApiResponse<SpecialtyResponseDTO>> Handle
        (CreateSpecialtyCommand command, CancellationToken cancellationToken)
    {
        var specialtyRepository = unitOfWork.SpecialtyRepository;
        var specialty = new Domain.Entities.Specialty
        {
            Description = command.Description,
            IsActive = command.IsActive
        };

        await specialtyRepository.AddAsync(specialty, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return ApiResponse<SpecialtyResponseDTO>.Created(mapper.Map<SpecialtyResponseDTO>(specialty));
    }
}