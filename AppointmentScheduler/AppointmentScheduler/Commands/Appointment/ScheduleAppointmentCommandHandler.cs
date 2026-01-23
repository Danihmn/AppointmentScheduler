using AppointmentScheduler.Common;
using AppointmentScheduler.Domain.Interfaces;

namespace AppointmentScheduler.Commands.Appointment;

public class
    ScheduleAppointmentCommandHandler(IUnitOfWork unitOfWork)
    : ICommandHandler<ScheduleAppointmentCommand, Domain.Entities.Appointment>
{
    public async Task<Domain.Entities.Appointment> Handle(ScheduleAppointmentCommand command,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var appointmentRepository = unitOfWork.GetRepository<Domain.Entities.Appointment>();
            var appointment = new Domain.Entities.Appointment
            {
                Date = command.Date,
                DoctorId = command.DoctorId,
                PatientId = command.PatientId,
                SpecialtyId = command.SpecialtyId,
                Notes = command.Notes,
                SecretaryId = command.SecretaryId
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