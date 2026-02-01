namespace AppointmentScheduler.Queries.Secretary
{
    public record GetSecretariesQuery () : IQuery<IEnumerable<Domain.Entities.Secretary>>;
}
