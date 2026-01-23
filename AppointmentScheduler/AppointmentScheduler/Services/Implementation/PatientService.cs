using AppointmentScheduler.Commands.Patient;
using AppointmentScheduler.Common;
using AppointmentScheduler.Domain.Entities;
using AppointmentScheduler.Domain.Enums;
using AppointmentScheduler.Services.Contract;

namespace AppointmentScheduler.Services.Implementation;

public class PatientService(ICommandHandler<CreatePatientCommand, Patient> commandHandler) : IPatientService
{
    public async Task<Patient> CreatePatientAsync
    (
        string name,
        string cpf,
        string phoneNumber,
        string email,
        EGender gender,
        string? notes,
        CancellationToken cancellationToken = default
    )
    {
        if (name == null || cpf == null || phoneNumber == null || email == null ||
            (gender != EGender.Male && gender != EGender.Female))
            throw new Exception("Invalid parameters");

        var command = new CreatePatientCommand(name, cpf, phoneNumber, email, gender, notes);
        return await commandHandler.Handle(command, cancellationToken);
    }
}