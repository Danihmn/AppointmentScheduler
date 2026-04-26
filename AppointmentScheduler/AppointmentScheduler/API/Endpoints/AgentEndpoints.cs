namespace AppointmentScheduler.API.Endpoints
{
    public static class AgentEndpoints
    {
        public static WebApplication MapAgentEndpoints (this WebApplication app)
        {
            RouteGroupBuilder agentGroup = app.MapGroup("/api/agent").WithTags("Agent").RequireAuthorization();

            agentGroup.MapPost(
                    "/ask",
                    async (PromptDTO input, IAgentService agentService, CancellationToken cancellationToken) =>
                    {
                        var response = await agentService.AskAgentAsync(input.UserInput, cancellationToken);
                        return new AgentResponseDTO(response);
                    })
                .WithDescription("Executa prompt para o Agente")
                .RequireAuthorization(policy => policy.RequireRole("Admin"));

            return app;
        }
    }
}