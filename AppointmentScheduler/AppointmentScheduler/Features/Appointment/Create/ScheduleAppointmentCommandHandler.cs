using AppointmentScheduler.Infrastructure.Services;

namespace AppointmentScheduler.Features.Appointment.Create;

public class ScheduleAppointmentCommandHandler
    (IUnitOfWork unitOfWork, IMapper mapper, INotificationService notificationService)
    : ICommandHandler<ScheduleAppointmentCommand, ApiResponse<AppointmentResponseDTO>>
{
    public async Task<ApiResponse<AppointmentResponseDTO>> Handle
        (ScheduleAppointmentCommand command, CancellationToken cancellationToken = default)
    {
        var appointmentRepository = unitOfWork.AppointmentRepository;
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

        var secretary = await unitOfWork.SecretaryRepository.GetByIdAsync(command.SecretaryId, cancellationToken);
        var patient = await unitOfWork.PatientRepository.GetByIdAsync(command.PatientId, cancellationToken);
        var doctor = await unitOfWork.DoctorRepository.GetByIdAsync(command.DoctorId, cancellationToken);

        if (secretary is not null && patient is not null && doctor is not null)
            await notificationService.NotifyAppointmentCreated(secretary.Name, patient.Name, command.Date, doctor.Name);

        return ApiResponse<AppointmentResponseDTO>.Created(mapper.Map<AppointmentResponseDTO>(appointment));
    }
}