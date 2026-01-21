using AppointmentScheduler.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppointmentScheduler.Infraestructure.Data.Repositories.Implementation;

public class RepositoryImplementation<T> : IRepository<T> where T : BaseEntity
{
    protected ApplicationDbContext Context;
    private DbSet<T> _dbSet;

    public RepositoryImplementation(ApplicationDbContext context)
    {
        Context = context;
        _dbSet = Context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet.ToListAsync(cancellationToken);
    }

    public async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _dbSet.FindAsync(id, cancellationToken);
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
    }

    public async void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public void Remove(T entity)
    {
        _dbSet.Update(entity);
    }
}