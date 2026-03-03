namespace AppointmentScheduler.Infraestructure.Services.Implementation
{
    public class LoginService
        (
            TokenService tokenService,
            TokenConfiguration tokenConfiguration,
            IQueryHandler<AuthenticateUserQuery, LoginSecretaryResponseDTO> queryHandlerAuthenticateUser
        ) : ILoginService
    {
        public async Task<LoginSecretaryResponseDTO> AuthenticateUserAsync
            (string username, string password, CancellationToken cancellationToken = default)
        {
            var query = new AuthenticateUserQuery(username, password);
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
