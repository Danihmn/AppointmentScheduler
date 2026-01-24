using AppointmentScheduler.Commands.Request;
using AppointmentScheduler.Common;
using AppointmentScheduler.Domain.Common;
using AppointmentScheduler.Domain.Enums;

namespace AppointmentScheduler.Domain.Entities;

public class Request : BaseEntity, ICommand<CreateRequestCommand>
{
    public ERequestStatus Status { get; set; } = ERequestStatus.Pending;
    public ERequestType Type { get; set; }
    public DateTime DesiredDate { get; set; }
    public string Description { get; set; } = null!;
    public string? Notes { get; set; }
    public EPriority Priority { get; set; } = EPriority.Medium;

    public int PatientId { get; set; }
    public int SpecialtyId { get; set; }
    public int? ProcessedBySecretaryId { get; set; }

    public virtual Patient Patient { get; set; } = null!;
    public virtual Specialty Specialty { get; set; } = null!;
    public virtual Secretary? ProcessedBySecretary { get; set; }
    public virtual Appointment? ResultingAppointment { get; set; }
}