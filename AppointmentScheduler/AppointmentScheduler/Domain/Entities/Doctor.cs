namespace AppointmentScheduler.Domain.Entities;

public class Doctor : BaseEntity
{
    public required string Name { get; set; }
    public required string Crm { get; set; }
    public required Specialty Specialty { get; set; }
    public required int PhoneNumber { get; set; }
    public required string Email { get; set; }
    public required DateTime HiringDate { get; set; }
    public required bool Active { get; set; }
    public required List<Schedule> Schedules { get; set; }
}