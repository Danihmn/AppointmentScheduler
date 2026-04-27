namespace AppointmentScheduler.Infrastructure.Persistence.Configurations;

public static class AgentConfiguration
{
    public static IServiceCollection AddAgentConfiguration
        (this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<AppointmentTools>();
        services.AddScoped<SpecialtyTools>();
        services.AddScoped<DoctorTools>();
        services.AddScoped<PatientTools>();
        services.AddScoped<SecretaryTools>();
        services.AddScoped<RequestTools>();

        services.AddSingleton(_ =>
            new AzureOpenAIClient(
                new Uri(configuration["AzureOpenAI:Endpoint"]!),
                new AzureKeyCredential(configuration["AzureOpenAI:ApiKey"]!)));

        services.AddScoped<IAgentService, AgentService>();

        return services;
    }
}