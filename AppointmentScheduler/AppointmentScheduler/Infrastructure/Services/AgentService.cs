namespace AppointmentScheduler.Infrastructure.Services
{
    public sealed class AgentService : IAgentService
    {
        private readonly AIAgent _agent;

        public AgentService
        (
            AzureOpenAIClient client,
            IConfiguration configuration,
            AppointmentTools appointmentTools,
            SpecialtyTools specialtyTools,
            DoctorTools doctorTools,
            PatientTools patientTools,
            SecretaryTools secretaryTools,
            RequestTools requestTools
        )
        {
            var deploymentModel = configuration["AzureOpenAI:Deployment"]
                ?? throw new InvalidOperationException("Missing configuration: AzureOpenAI:Deployment");
            var chatClient = client.GetChatClient(deploymentModel);

            _agent = chatClient.AsAIAgent(
                instructions: "You are an agent who will provide important information about a medical clinic, such as appointment scheduling, doctors, patients, receptionists, and specialties. The system is always used by receptionists (internal employees of the clinic), provide relevant information for receptionists. Always respond in Portuguese - Brazil.",
                tools:
                [
                    AIFunctionFactory.Create(appointmentTools.GetAllAppointmentsAsync),
                    AIFunctionFactory.Create(appointmentTools.GetAppointmentByIdAsync),
                    AIFunctionFactory.Create(appointmentTools.CreateAppointmentAsync),
                    AIFunctionFactory.Create(appointmentTools.UpdateAppointmentAsync),
                    AIFunctionFactory.Create(specialtyTools.GetAllSpecialtiesAsync),
                    AIFunctionFactory.Create(specialtyTools.GetSpecialtyByIdAsync),
                    AIFunctionFactory.Create(specialtyTools.CreateSpecialtyAsync),
                    AIFunctionFactory.Create(specialtyTools.UpdateSpecialtyAsync),
                    AIFunctionFactory.Create(doctorTools.GetAllDoctorsAsync),
                    AIFunctionFactory.Create(doctorTools.GetDoctorByIdAsync),
                    AIFunctionFactory.Create(doctorTools.CreateDoctorAsync),
                    AIFunctionFactory.Create(doctorTools.UpdateDoctorAsync),
                    AIFunctionFactory.Create(patientTools.GetAllPatientsAsync),
                    AIFunctionFactory.Create(patientTools.GetPatientByIdAsync),
                    AIFunctionFactory.Create(patientTools.CreatePatientAsync),
                    AIFunctionFactory.Create(patientTools.UpdatePatientAsync),
                    AIFunctionFactory.Create(secretaryTools.GetAllSecretariesAsync),
                    AIFunctionFactory.Create(secretaryTools.GetSecretaryByIdAsync),
                    AIFunctionFactory.Create(secretaryTools.CreateSecretaryAsync),
                    AIFunctionFactory.Create(secretaryTools.UpdateSecretaryAsync),
                    AIFunctionFactory.Create(requestTools.GetAllRequestsAsync),
                    AIFunctionFactory.Create(requestTools.GetRequestByIdAsync),
                    AIFunctionFactory.Create(requestTools.CreateRequestAsync),
                    AIFunctionFactory.Create(requestTools.UpdateRequestAsync),
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