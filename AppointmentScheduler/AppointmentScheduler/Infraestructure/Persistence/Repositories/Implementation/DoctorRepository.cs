using AppointmentScheduler.Infraestructure.Persistence.ApplicationDbContext;
using AppointmentScheduler.Infraestructure.Persistence.Repositories.Contract;
using AppointmentScheduler.Infraestructure.Persistence.Repositories.Implementation.Generic;

namespace AppointmentScheduler.Infraestructure.Persistence.Repositories.Implementation
{
    public class DoctorRepository (AppDbContext context)
        : Repository<Doctor>(context), IDoctorRepository
    {
        private readonly DbSet<Doctor> _dbSet = context.Set<Doctor>();

        public async Task<IEnumerable<Doctor>> GetAllWithDetailAsync (CancellationToken cancellationToken = default)
        => await _dbSet
            .Include(doctor => (doctor).Specialty)
            .Include(doctor => (doctor).Appointments)
            .ToListAsync(cancellationToken);

        public async Task<Doctor?> GetByIdWithDetailsAsync (int id, CancellationToken cancellationToken = default)
        => await _dbSet
            .Include(doctor => (doctor).Specialty)
            .Include(doctor => (doctor).Appointments)
            .FirstOrDefaultAsync(doctor => doctor.Id == id, cancellationToken);
    }
}
