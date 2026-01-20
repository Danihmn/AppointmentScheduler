using AppointmentScheduler.Domain.Enums;

namespace AppointmentScheduler.Domain.Entities;

public class Event : BaseEntity
{
    public required EEventRegister Category { get; set; }
    public required DateTime Date { get; set; }
    public required Appointment Appointment { get; set; }
    public string? Notes { get; set; }
}