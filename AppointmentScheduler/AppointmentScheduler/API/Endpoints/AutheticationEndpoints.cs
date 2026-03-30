namespace AppointmentScheduler.API.Endpoints;

public static class AutheticationEndpoints
{
    public static WebApplication MapLoginEndpoints (this WebApplication app)
    {
        RouteGroupBuilder loginGroup = app.MapGroup("/api/authentication").WithTags("Authentication");

        loginGroup.MapPost("/login", async (LoginCredentialsDTO credentials, IQueryHandler<AuthenticateSecretaryQuery, ApiResponse<LoginSecretaryResponseDTO>> queryHandlerAuthenticateUser, CancellationToken cancellationToken = default) =>
            TypedResults.Ok(await queryHandlerAuthenticateUser.Handle(new AuthenticateSecretaryQuery(credentials.Username, credentials.Password), cancellationToken))).WithDescription("Autentica usuário");

        return app;
    }
}