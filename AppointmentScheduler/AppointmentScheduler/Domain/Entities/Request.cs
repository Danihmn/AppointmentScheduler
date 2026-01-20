using AppointmentScheduler.Domain.Enums;

namespace AppointmentScheduler.Domain.Entities;

public class Request : BaseEntity
{
    public required ERequestStatus Status { get; set; }
    public required ERequestType Type { get; set; }
    public required DateTime RequestDate { get; set; }
    public required Patient Patient { get; set; }
    public required Specialty Specialty { get; set; }
}