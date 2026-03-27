using AppointmentScheduler.Infraestructure.Persistence.ApplicationDbContext;
using AppointmentScheduler.Infraestructure.Persistence.Repositories.Contract;
using AppointmentScheduler.Infraestructure.Persistence.Repositories.Implementation.Generic;

namespace AppointmentScheduler.Infraestructure.Persistence.Repositories.Implementation
{
    public class LoginRepository (AppDbContext context) : Repository<Secretary>(context), ILoginRepository
    {
        private readonly DbSet<Secretary> _dbSet = context.Set<Secretary>();

        public async Task<Secretary?> GetByUsername (string username, CancellationToken cancellationToken = default)
        => await _dbSet.FirstOrDefaultAsync(secretary => secretary.Username == username, cancellationToken);
    }
}
