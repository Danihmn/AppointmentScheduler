using AppointmentScheduler.Infrastructure.Persistence.ApplicationDbContext;
using AppointmentScheduler.Infrastructure.Persistence.Repositories.Contract;
using AppointmentScheduler.Infrastructure.Persistence.Repositories.Implementation.Generic;

namespace AppointmentScheduler.Infrastructure.Persistence.Repositories.Implementation
{
    public class RequestRepository (AppDbContext context)
        : Repository<Request>(context), IRequestRepository
    {
        private readonly DbSet<Request> _dbSet = context.Set<Request>();

        public async Task<IEnumerable<Request>> GetAllWithDetailAsync (CancellationToken cancellationToken = default)
        => await _dbSet
            .Include(request => request.Patient)
            .Include(request => request.Specialty)
            .Include(request => request.ProcessedBySecretary)
            .Include(request => request.ResultingAppointment)
            .ToListAsync(cancellationToken);

        public async Task<Request?> GetByIdWithDetailsAsync (int id, CancellationToken cancellationToken = default)
        => await _dbSet
            .Include(request => request.Patient)
            .Include(request => request.Specialty)
            .Include(request => request.ProcessedBySecretary)
            .Include(request => request.ResultingAppointment)
            .FirstOrDefaultAsync(request => request.Id == id, cancellationToken);
    }
}
