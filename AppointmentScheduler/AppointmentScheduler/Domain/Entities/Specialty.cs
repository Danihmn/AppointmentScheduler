namespace AppointmentScheduler.Domain.Entities;

public class Specialty : BaseEntity
{
    public string Description { get; set; } = null!;

    public ICollection<Request> Requests { get; set; } = new List<Request>();
}