using AppointmentScheduler.Commands.AppointmentCommand;
using AppointmentScheduler.Common;
using AppointmentScheduler.Domain.Interfaces;

namespace AppointmentScheduler.Commands.Appointment;

public class
    ScheduleAppointmentCommandHandler : ICommandHandler<ScheduleAppointmentCommand, Domain.Entities.Appointment>
{
    private readonly IUnitOfWork _unitOfWork;

    public ScheduleAppointmentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.Appointment> Handle(ScheduleAppointmentCommand command,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var appointmentRepository = _unitOfWork.GetRepository<Domain.Entities.Appointment>();
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
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return appointment;
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}