namespace AppointmentScheduler.Infraestructure.Data;

public class UnitOfWork (ApplicationDbContext context) : IUnitOfWork
{
    private bool _disposed = false;
    private readonly Dictionary<Type, object> _repositories = [];

    public IRepository<T> GetRepository<T> () where T : BaseEntity
    {
        var type = typeof(T);

        if (!_repositories.TryGetValue(type, out object? value))
        {
            var repositoryType = typeof(RepositoryImplementation<>).MakeGenericType(type);
            var repositoryInstance = Activator.CreateInstance(repositoryType, context);

            value = repositoryInstance!;
            _repositories[type] = value;
        }

        return (IRepository<T>)value;
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