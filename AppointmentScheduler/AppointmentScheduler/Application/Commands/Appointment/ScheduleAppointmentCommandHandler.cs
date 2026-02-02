namespace AppointmentScheduler.Application.Commands.Appointment;

public class
    ScheduleAppointmentCommandHandler (IUnitOfWork unitOfWork)
    : ICommandHandler<ScheduleAppointmentCommand, Domain.Entities.Appointment>
{
    public async Task<Domain.Entities.Appointment> Handle (ScheduleAppointmentCommand command,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var appointmentRepository = unitOfWork.GetRepository<Domain.Entities.Appointment>();
            var appointment = new Domain.Entities.Appointment
            {
                Date = command.Date,
                Status = command.Status,
                RequestId = command.RequestId,
                PatientId = command.PatientId,
                DoctorId = command.DoctorId,
                SpecialtyId = command.SpecialtyId,
                SecretaryId = command.SecretaryId,
                Notes = command.Notes
            };

            await appointmentRepository.AddAsync(appointment, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return appointment;
        }
        catch (Exception ex)
        {
            throw new Exception("Error while creating new Appointment", ex);
        }
    }
}