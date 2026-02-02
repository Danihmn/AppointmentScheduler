using AppointmentScheduler.Application.Commands.Doctor;
using AppointmentScheduler.Application.Common;
using AppointmentScheduler.Application.Queries.Doctor;
using AppointmentScheduler.Infraestructure.Services.Contract;

namespace AppointmentScheduler.Infraestructure.Services.Implementation;

public class DoctorService
    (
        IQueryHandler<GetDoctorsQuery, IEnumerable<Doctor>> queryHandlerGetAllDoctors,
        IQueryHandler<GetDoctorByIdQuery, Doctor> queryHandlerGetDoctorById,
        ICommandHandler<CreateDoctorCommand, Doctor> commandHandlerCreateDoctor
    ) : IDoctorService
{
    public async Task<IEnumerable<Doctor>> GetDoctorsAsync (CancellationToken cancellationToken = default)
    {
        var query = new GetDoctorsQuery();
        return await queryHandlerGetAllDoctors.Handle(query, cancellationToken);
    }

    public async Task<Doctor> GetDoctorByIdAsync (int id, CancellationToken cancellationToken = default)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);

        var query = new GetDoctorByIdQuery(id);
        return await queryHandlerGetDoctorById.Handle(query, cancellationToken);
    }

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

        return await commandHandlerCreateDoctor.Handle(command, cancellationToken);
    }
}