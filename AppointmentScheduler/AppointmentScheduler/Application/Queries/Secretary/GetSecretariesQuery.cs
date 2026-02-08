namespace AppointmentScheduler.Application.Queries.Secretary
{
    public record GetSecretariesQuery () : IQuery<IEnumerable<SecretaryResponseDTO>>;
}
