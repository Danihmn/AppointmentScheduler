using AppointmentScheduler.Commands.Doctor;
using AppointmentScheduler.Common;
using AppointmentScheduler.Domain.Entities;
using AppointmentScheduler.Services.Contract;

namespace AppointmentScheduler.Services.Implementation;

public class DoctorService(ICommandHandler<CreateDoctorCommand, Doctor> commandHandler) : IDoctorService
{
    public async Task<Doctor> CreateDoctorAsync
    (
        string name,
        string crm,
        string phoneNumber,
        string email,
        DateTime hiringDate, bool active,
        int specialtyId,
        CancellationToken cancellationToken = default
    )
    {
        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(crm) || string.IsNullOrEmpty(phoneNumber) ||
            string.IsNullOrEmpty(email) || hiringDate == DateTime.MinValue || specialtyId <= 0)
            throw new Exception("Invalid data");

        // It needs to check if exists a Specialty with specialtyId before create

        var command = new CreateDoctorCommand(name, crm, phoneNumber, email, hiringDate, active, specialtyId);
        return await commandHandler.Handle(command, cancellationToken);
    }
}