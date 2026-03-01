namespace AppointmentScheduler.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IAppointmentRepository AppointmentRepository { get; }
    IDoctorRepository DoctorRepository { get; }
    IPatientRepository PatientRepository { get; }
    IRequestRepository RequestRepository { get; }
    ISecretaryRepository SecretaryRepository { get; }
    ISpecialtyRepository SpecialtyRepository { get; }
    ILoginRepository LoginRepository { get; }

    IRepository<T> GetRepository<T> () where T : BaseEntity;
    Task<int> SaveChangesAsync (CancellationToken cancellationToken = default);
}