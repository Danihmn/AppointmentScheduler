using AppointmentScheduler.Commands.Patient;
using AppointmentScheduler.Common;
using AppointmentScheduler.Domain.Entities;
using AppointmentScheduler.Domain.Enums;
using AppointmentScheduler.Queries.Patient;
using AppointmentScheduler.Services.Contract;

namespace AppointmentScheduler.Services.Implementation;

public class PatientService
    (
        IQueryHandler<GetPatientsQuery, IEnumerable<Patient>> queryHandlerGetAllPatients,
        IQueryHandler<GetPatientByIdQuery, Patient> queryHandlerGetPatientById,
        ICommandHandler<CreatePatientCommand, Patient> commandHandlerCreatePatients
    ) : IPatientService
{
    public async Task<IEnumerable<Patient>> GetPatientsAsync (CancellationToken cancellationToken = default)
    {
        var query = new GetPatientsQuery();
        return await queryHandlerGetAllPatients.Handle(query, cancellationToken);
    }

    public async Task<Patient> GetPatientByIdAsync (int id, CancellationToken cancellationToken = default)
    {
        var query = new GetPatientByIdQuery(id);
        return await queryHandlerGetPatientById.Handle(query, cancellationToken);
    }

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

        return await commandHandlerCreatePatients.Handle(command, cancellationToken);
    }
}