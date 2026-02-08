namespace AppointmentScheduler.Infraestructure.Data.Repositories.Implementation
{
    public class PatientRepository (ApplicationDbContext context)
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
