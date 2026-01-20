namespace AppointmentScheduler.Domain.Entities;

public class WaitingList : BaseEntity
{
    public required List<Request> Requests { get; set; }
}