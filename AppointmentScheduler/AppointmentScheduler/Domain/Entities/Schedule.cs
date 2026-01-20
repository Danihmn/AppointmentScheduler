namespace AppointmentScheduler.Domain.Entities;

public class Schedule : BaseEntity
{
    public required Doctor Doctor { get; set; }
    public required DateTime Date { get; set; }
    public required bool Disposition { get; set; }
    public required Appointment Appointment { get; set; }
}