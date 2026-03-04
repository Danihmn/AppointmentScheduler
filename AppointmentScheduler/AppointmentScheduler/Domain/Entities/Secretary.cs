namespace AppointmentScheduler.Domain.Entities;

public class Secretary : BaseEntity
{
    public string Username { get; set; }
    public string HashedPassword { get; set; }
    public string Name { get; set; } = null!;
    public string Cpf { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Email { get; set; } = null!;
    public DateTime HiringDate { get; set; }
    public bool Active { get; set; }
    public ERole? Role { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = [];
    public virtual ICollection<Request> ProcessedRequests { get; set; } = [];
}