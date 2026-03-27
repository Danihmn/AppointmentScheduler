using AppointmentScheduler.Features.Common.CQRS;
using AppointmentScheduler.Features.Secretary.Authenticate;
using AppointmentScheduler.Infraestructure.Authentication.Configuration;
using AppointmentScheduler.Infraestructure.Authentication.Services.Contract;

namespace AppointmentScheduler.Infraestructure.Services.Implementation
{
    public class LoginService
        (
            ITokenService tokenService,
            TokenConfiguration tokenConfiguration,
            IQueryHandler<AuthenticateSecretaryQuery, LoginSecretaryResponseDTO> queryHandlerAuthenticateUser
        ) : ILoginService
    {
        public async Task<LoginSecretaryResponseDTO> AuthenticateUserAsync
            (string username, string password, CancellationToken cancellationToken = default)
        {
            var query = new AuthenticateSecretaryQuery(username, password);
            var response = await queryHandlerAuthenticateUser.Handle(query, cancellationToken)
                ?? throw new UnauthorizedAccessException("Usuário ou senha inválidos");

            return GenerateToken(response);
        }

        private LoginSecretaryResponseDTO GenerateToken (LoginSecretaryResponseDTO user)
        {
            var additionalClaims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new(JwtRegisteredClaimNames.UniqueName, user.Name),
            };

            user.AccessToken = tokenService.Generate(user, additionalClaims);

            return user;
        }
    }
}
