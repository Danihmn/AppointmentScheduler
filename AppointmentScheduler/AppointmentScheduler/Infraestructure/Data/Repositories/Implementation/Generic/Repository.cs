namespace AppointmentScheduler.Infraestructure.Data.Repositories.Implementation.Generic;

public class Repository<T> (ApplicationDbContext context) : IRepository<T> where T : BaseEntity
{
    private readonly DbSet<T> _dbSet = context.Set<T>();

    public async Task<IEnumerable<T>> GetAllAsync (CancellationToken cancellationToken = default)
    => await _dbSet.ToListAsync(cancellationToken);

    public async Task<T?> GetByIdAsync (int id, CancellationToken cancellationToken = default)
    => await _dbSet.FindAsync([id], cancellationToken);

    public async Task AddAsync (T entity, CancellationToken cancellationToken = default)
    => await _dbSet.AddAsync(entity, cancellationToken);

    public void Update (T entity) => _dbSet.Update(entity);

    public void Remove (T entity) => _dbSet.Remove(entity);
}