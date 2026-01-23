using AppointmentScheduler.Domain.Common;

namespace AppointmentScheduler.Domain.Entities;

public class Specialty : BaseEntity
{
    public string Description { get; set; } = null!;
    public bool IsActive { get; set; } = true;

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();
    public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
}