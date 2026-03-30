using AppointmentScheduler.Infrastructure.Persistence.ApplicationDbContext;
using AppointmentScheduler.Infrastructure.Persistence.Repositories.Contract;
using AppointmentScheduler.Infrastructure.Persistence.Repositories.Implementation.Generic;

namespace AppointmentScheduler.Infrastructure.Persistence.Repositories.Implementation
{
    public class PatientRepository (AppDbContext context)
        : Repository<Patient>(context), IPatientRepository
    {
        private readonly DbSet<Patient> _dbSet = context.Set<Patient>();

        public async Task<IEnumerable<Patient>> GetAllWithDetailAsync (CancellationToken cancellationToken = default)
        => await _dbSet
            .Include(patient => patient.Appointments)
            .Include(patient => patient.Requests)
            .ToListAsync(cancellationToken);

        public async Task<Patient?> GetByIdWithDetailsAsync (int id, CancellationToken cancellationToken = default)
        => await _dbSet
            .Include(patient => patient.Appointments)
            .Include(patient => patient.Requests)
            .FirstOrDefaultAsync(patient => patient.Id == id, cancellationToken);
    }
}
