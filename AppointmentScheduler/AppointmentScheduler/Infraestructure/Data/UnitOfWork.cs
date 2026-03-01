namespace AppointmentScheduler.Infraestructure.Data;

public class UnitOfWork (ApplicationDbContext context) : IUnitOfWork
{
    private bool _disposed = false;

    private IAppointmentRepository? _appointmentRepository;
    private IDoctorRepository? _doctorRepository;
    private IPatientRepository? _patientRepository;
    private IRequestRepository? _requestRepository;
    private ISecretaryRepository? _secretaryRepository;
    private ISpecialtyRepository? _specialtyRepository;
    private ILoginRepository? _loginRepository;

    public IAppointmentRepository AppointmentRepository => _appointmentRepository ??= new AppointmentRepository(context);
    public IDoctorRepository DoctorRepository => _doctorRepository ??= new DoctorRepository(context);
    public IPatientRepository PatientRepository => _patientRepository ??= new PatientRepository(context);
    public IRequestRepository RequestRepository => _requestRepository ??= new RequestRepository(context);
    public ISecretaryRepository SecretaryRepository => _secretaryRepository ??= new SecretaryRepository(context);
    public ISpecialtyRepository SpecialtyRepository => _specialtyRepository ??= new SpecialtyRepository(context);
    public ILoginRepository LoginRepository => _loginRepository ??= new LoginRepository(context);

    public IRepository<T> GetRepository<T> () where T : BaseEntity
    => typeof(T).Name switch
    {
        nameof(Appointment) => (IRepository<T>)AppointmentRepository,
        nameof(Doctor) => (IRepository<T>)DoctorRepository,
        nameof(Patient) => (IRepository<T>)PatientRepository,
        nameof(Request) => (IRepository<T>)RequestRepository,
        nameof(Secretary) => (IRepository<T>)SecretaryRepository,
        nameof(Specialty) => (IRepository<T>)SpecialtyRepository,
        _ => throw new ArgumentException($"No repository found for type {typeof(T).Name}")
    };

    public async Task<int> SaveChangesAsync (CancellationToken cancellationToken = default)
    => await context.SaveChangesAsync(cancellationToken);

    protected virtual void Dispose (bool disposing)
    {
        if (_disposed) return;
        if (disposing) context.Dispose();

        _disposed = true;
    }

    public void Dispose ()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}