namespace AppointmentScheduler.Infraestructure.Data;

public class UnitOfWork (ApplicationDbContext context) : IUnitOfWork
{
    private bool _disposed = false;

    private IAppointmentRepository? _appointmentRepository;

    public IAppointmentRepository AppointmentRepository
        => _appointmentRepository ??= new AppointmentRepository(context);

    public IRepository<T> GetRepository<T> () where T : BaseEntity
    {
        return typeof(T).Name switch
        {
            nameof(Appointment) => (IRepository<T>)AppointmentRepository,
            _ => throw new ArgumentException($"No repository found for type {typeof(T).Name}")
        };
    }

    public async Task<int> SaveChangesAsync (CancellationToken cancellationToken = default)
    {
        return await context.SaveChangesAsync(cancellationToken);
    }

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