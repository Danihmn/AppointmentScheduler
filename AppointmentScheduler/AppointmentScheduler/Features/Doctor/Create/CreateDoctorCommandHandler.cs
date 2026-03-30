using AppointmentScheduler.Features.Common.CQRS;
using AppointmentScheduler.Infrastructure.Persistence.UnifOfWork;

namespace AppointmentScheduler.Features.Doctor.Create;

public class CreateDoctorCommandHandler (IUnitOfWork unitOfWork)
    : ICommandHandler<CreateDoctorCommand, Domain.Entities.Doctor>
{
    public async Task<Domain.Entities.Doctor> Handle (CreateDoctorCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var doctorRepository = unitOfWork.GetRepository<Domain.Entities.Doctor>();
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

            return doctor;
        }
        catch (Exception ex)
        {
            throw new Exception("Error while creating new Doctor", ex);
        }
    }
}