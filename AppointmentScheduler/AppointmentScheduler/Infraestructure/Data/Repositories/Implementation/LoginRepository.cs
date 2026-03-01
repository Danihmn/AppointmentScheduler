namespace AppointmentScheduler.Infraestructure.Data.Repositories.Implementation
{
    public class LoginRepository (ApplicationDbContext context) : Repository<Secretary>(context), ILoginRepository
    {
        private readonly DbSet<Secretary> _dbSet = context.Set<Secretary>();

        public async Task<Secretary?> GetByUsername (string username, CancellationToken cancellationToken = default)
        => await _dbSet.FirstOrDefaultAsync(secretary => secretary.Username == username, cancellationToken);
    }
}
