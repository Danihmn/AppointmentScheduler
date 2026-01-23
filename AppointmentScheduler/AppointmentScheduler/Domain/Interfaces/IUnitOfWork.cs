using AppointmentScheduler.Domain.Common;
using AppointmentScheduler.Domain.Entities;
using AppointmentScheduler.Infraestructure.Data.Repositories;

namespace AppointmentScheduler.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    IRepository<T> GetRepository<T>() where T : BaseEntity;
}