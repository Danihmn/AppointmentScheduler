using AppointmentScheduler.Application.Common;

namespace AppointmentScheduler.Application.Commands.Patient;

public class CreatePatientCommandHandler (IUnitOfWork unitOfWork)
    : ICommandHandler<CreatePatientCommand, Domain.Entities.Patient>
{
    public async Task<Domain.Entities.Patient> Handle (CreatePatientCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var patientRepository = unitOfWork.GetRepository<Domain.Entities.Patient>();
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

            return patient;
        }
        catch (Exception ex)
        {
            throw new Exception("Error while creating new Patient", ex);
        }
    }
}