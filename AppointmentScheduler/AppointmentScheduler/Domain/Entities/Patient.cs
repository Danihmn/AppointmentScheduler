using AppointmentScheduler.Domain.Enums;

namespace AppointmentScheduler.Domain.Entities;

public class Patient : BaseEntity
{
    public required string Name { get; set; }
    public required int Cpf { get; set; }
    public required int PhoneNumber { get; set; }
    public required string Email { get; set; }
    public required EGender Gender { get; set; }
    public string? Notes { get; set; }
    public required List<Appointment> Appointments { get; set; }
}