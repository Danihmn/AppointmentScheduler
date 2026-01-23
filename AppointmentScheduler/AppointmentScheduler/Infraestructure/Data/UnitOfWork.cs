using AppointmentScheduler.Domain.Common;
using AppointmentScheduler.Domain.Entities;
using AppointmentScheduler.Domain.Interfaces;
using AppointmentScheduler.Infraestructure.Data.Repositories;
using AppointmentScheduler.Infraestructure.Data.Repositories.Implementation;

namespace AppointmentScheduler.Infraestructure.Data;

public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
{
    private bool _disposed = false;
    private readonly Dictionary<Type, object> _repositories = new();

    public IRepository<T> GetRepository<T>() where T : BaseEntity
    {
        var type = typeof(T);

        if (!_repositories.ContainsKey(type))
        {
            var repositoryType = typeof(RepositoryImplementation<>).MakeGenericType(type);
            var repositoryInstance = Activator.CreateInstance(repositoryType, context);

            _repositories[type] = repositoryInstance!;
        }

        return (IRepository<T>)_repositories[type];
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await context.SaveChangesAsync(cancellationToken);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed) return;
        if (disposing) context.Dispose();

        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}