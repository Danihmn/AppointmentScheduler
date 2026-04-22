namespace AppointmentScheduler.Domain.Entities;

public class Appointment : BaseEntity
{
    public DateTime Date { get; set; }
    public EAppointmentStatus Status { get; set; }
    public string? Notes { get; set; }

    public int RequestId { get; set; }
    public int DoctorId { get; set; }

    public virtual Request Request { get; set; } = null!;
    public virtual Doctor Doctor { get; set; } = null!;
}