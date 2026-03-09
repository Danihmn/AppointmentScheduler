namespace AppointmentScheduler.Endpoints;

public static class AutheticationEndpoints
{
    public static WebApplication MapLoginEndpoints (this WebApplication app)
    {
        RouteGroupBuilder loginGroup = app.MapGroup("/api/authentication").WithTags("Authentication");

        loginGroup.MapPost("/login", async (string username, string password, ILoginService loginService) =>
        {
            try
            {
                var response = await loginService.AuthenticateUserAsync(username, password);
                return Results.Ok(response);
            }
            catch (UnauthorizedAccessException)
            {
                return Results.Unauthorized();
            }
        }).WithDescription("Autentica usuário");

        return app;
    }
}