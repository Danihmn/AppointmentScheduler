namespace AppointmentScheduler.Infrastructure.Services
{
    public interface IAgentService
    {
        Task<string> AskAgentAsync (string userInput, CancellationToken cancellationToken);
    }
}
