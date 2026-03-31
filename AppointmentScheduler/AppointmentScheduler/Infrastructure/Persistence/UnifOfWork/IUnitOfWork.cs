namespace AppointmentScheduler.Infrastructure.Persistence.UnifOfWork;

public interface IUnitOfWork : IDisposable
{
    IAppointmentRepository AppointmentRepository { get; }
    IDoctorRepository DoctorRepository { get; }
    IPatientRepository PatientRepository { get; }
    IRequestRepository RequestRepository { get; }
    ISecretaryRepository SecretaryRepository { get; }
    ISpecialtyRepository SpecialtyRepository { get; }
    ILoginRepository LoginRepository { get; }

    Task<int> SaveChangesAsync (CancellationToken cancellationToken = default);
}