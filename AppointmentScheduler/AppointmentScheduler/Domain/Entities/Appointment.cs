using AppointmentScheduler.Domain.Enums;

namespace AppointmentScheduler.Domain.Entities;

public class Appointment : BaseEntity
{
    public required DateTime Date { get; set; }
    public required EStatus Status { get; set; }
    public required Patient Patient { get; set; }
    public required Doctor Doctor { get; set; }
    public required Specialty Specialty { get; set; }
    public string? Notes { get; set; }
    public required Secretary Secretary { get; set; }
}