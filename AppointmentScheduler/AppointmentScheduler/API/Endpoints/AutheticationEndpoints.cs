using AppointmentScheduler.Features.Secretary.Authenticate;

namespace AppointmentScheduler.API.Endpoints;

public static class AutheticationEndpoints
{
    public static WebApplication MapLoginEndpoints (this WebApplication app)
    {
        RouteGroupBuilder loginGroup = app.MapGroup("/api/authentication").WithTags("Authentication");

        loginGroup.MapPost("/login", async (LoginCredentialsDTO credentials, ILoginService loginService) =>
        {
            try
            {
                var response = await loginService.AuthenticateUserAsync(credentials.Username, credentials.Password);
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