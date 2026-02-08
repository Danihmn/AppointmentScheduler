namespace AppointmentScheduler.Infraestructure.Data.Repositories.Implementation
{
    public class SpecialtyRepository (ApplicationDbContext context)
        : Repository<Specialty>(context), ISpecialtyRepository
    {
        private readonly DbSet<Specialty> _dbSet = context.Set<Specialty>();

        public async Task<IEnumerable<Specialty>> GetAllWithDetailAsync (CancellationToken cancellationToken = default)
        => await _dbSet
            .Include(specialty => specialty.Requests)
            .Include(specialty => specialty.Doctors)
            .ToListAsync(cancellationToken);

        public async Task<Specialty?> GetByIdWithDetailsAsync (int id, CancellationToken cancellationToken = default)
        => await _dbSet
            .Include(specialty => specialty.Requests)
            .Include(specialty => specialty.Doctors)
            .FirstOrDefaultAsync(specialty => specialty.Id == id, cancellationToken);
    }
}
