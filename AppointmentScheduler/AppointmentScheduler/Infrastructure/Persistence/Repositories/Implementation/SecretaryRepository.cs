using AppointmentScheduler.Infrastructure.Persistence.ApplicationDbContext;
using AppointmentScheduler.Infrastructure.Persistence.Repositories.Contract;
using AppointmentScheduler.Infrastructure.Persistence.Repositories.Implementation.Generic;

namespace AppointmentScheduler.Infrastructure.Persistence.Repositories.Implementation
{
    public class SecretaryRepository (AppDbContext context)
        : Repository<Secretary>(context), ISecretaryRepository
    {
        private readonly DbSet<Secretary> _dbSet = context.Set<Secretary>();

        public async Task<IEnumerable<Secretary>> GetAllWithDetailAsync (CancellationToken cancellationToken = default)
        => await _dbSet
            .Include(secretary => secretary.Appointments)
            .Include(secretary => secretary.ProcessedRequests)
            .ToListAsync(cancellationToken);

        public async Task<Secretary?> GetByIdWithDetailsAsync (int id, CancellationToken cancellationToken = default)
        => await _dbSet
            .Include(secretary => secretary.Appointments)
            .Include(secretary => secretary.ProcessedRequests)
            .FirstOrDefaultAsync(secretary => secretary.Id == id, cancellationToken);
    }
}
