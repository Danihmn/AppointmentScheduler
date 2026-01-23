using AppointmentScheduler.Domain.Common;
using AppointmentScheduler.Domain.Enums;

namespace AppointmentScheduler.Domain.Entities;

public class Appointment : BaseEntity
{
    public DateTime Date { get; set; }
    public EStatus Status { get; set; }
    public string? Notes { get; set; }

    public int PatientId { get; set; }
    public int DoctorId { get; set; }
    public int SpecialtyId { get; set; }
    public int SecretaryId { get; set; }

    public virtual Patient Patient { get; set; } = null!;
    public virtual Doctor Doctor { get; set; } = null!;
    public virtual Specialty Specialty { get; set; } = null!;
    public virtual Secretary Secretary { get; set; } = null!;
}