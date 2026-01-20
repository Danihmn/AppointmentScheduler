namespace AppointmentScheduler.Domain.Entities;

public class Secretary : BaseEntity
{
    public required string Name { get; set; }
    public required int Cpf { get; set; }
    public required int PhoneNumber { get; set; }
    public required string Email { get; set; }
    public required DateTime CreatedAt { get; set; }
    public required bool Active { get; set; }

    public void VerifyRequest(Request request)
    {
    }
}