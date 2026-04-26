namespace AppointmentScheduler.Infrastructure.Services
{
    public sealed class AgentService : IAgentService
    {
        private readonly AIAgent _agent;

        public AgentService (AzureOpenAIClient client, IConfiguration configuration, AppointmentTools appointmentTools)
        {
            var deploymentModel = configuration["AzureOpenAI:Deployment"]
                ?? throw new InvalidOperationException("Missing configuration: AzureOpenAI:Deployment");
            var chatClient = client.GetChatClient(deploymentModel);

            _agent = chatClient.AsAIAgent(
                instructions: "You are an agent who will provide important information about a medical clinic, such as appointment scheduling, doctors, patients, receptionists, and specialties. The system is always used by receptionists (internal employees of the clinic), provide relevant information for receptionists. Always respond in Portuguese - Brazil.",
                tools: [
                    AIFunctionFactory.Create(appointmentTools.GetAllAppointmentsAsync),
                    AIFunctionFactory.Create(appointmentTools.GetAppointmentByIdAsync),
                    AIFunctionFactory.Create(appointmentTools.CreateAppointmentAsync),
                    AIFunctionFactory.Create(appointmentTools.UpdateAppointmentAsync)
                    ]
            );
        }

        public async Task<string> AskAgentAsync (string userInput, CancellationToken cancellationToken)
        {
            var message = await _agent.RunAsync(userInput, cancellationToken: cancellationToken);
            return string.Concat(message.Messages.Last().Contents.Select(message => message.ToString()));
        }
    }
}