namespace AppointmentScheduler.Domain.Entities;

public class Doctor : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Crm { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Email { get; set; } = null!;
    public DateTime HiringDate { get; set; }
    public bool Active { get; set; } = true;

    public int SpecialtyId { get; set; }

    public virtual Specialty Specialty { get; set; } = null!;
    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}