using AppointmentScheduler.Domain.Enums;

namespace AppointmentScheduler.Domain.Entities;

public class Patient : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Cpf { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Email { get; set; } = null!;
    public EGender Gender { get; set; }
    public string? Notes { get; set; } = null!;

    public required ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    public required ICollection<Request> Requests { get; set; } = new List<Request>();
}