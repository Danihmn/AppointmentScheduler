using AppointmentScheduler.Infraestructure.Persistence.ApplicationDbContext;
using AppointmentScheduler.Infraestructure.Persistence.Repositories.Contract;
using AppointmentScheduler.Infraestructure.Persistence.Repositories.Implementation.Generic;

namespace AppointmentScheduler.Infraestructure.Persistence.Repositories.Implementation
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
