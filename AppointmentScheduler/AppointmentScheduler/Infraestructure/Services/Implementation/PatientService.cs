namespace AppointmentScheduler.Infraestructure.Services.Implementation;

public class PatientService
    (
        IQueryHandler<GetPatientsQuery, IEnumerable<PatientResponseDTO>> queryHandlerGetAllPatients,
        IQueryHandler<GetPatientByIdQuery, PatientResponseDTO> queryHandlerGetPatientById,
        ICommandHandler<CreatePatientCommand, Patient> commandHandlerCreatePatients
    ) : IPatientService
{
    public async Task<IEnumerable<PatientResponseDTO>> GetPatientsAsync (CancellationToken cancellationToken = default)
    {
        var query = new GetPatientsQuery();
        return await queryHandlerGetAllPatients.Handle(query, cancellationToken);
    }

    public async Task<PatientResponseDTO> GetPatientByIdAsync (int id, CancellationToken cancellationToken = default)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);

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