namespace AppointmentScheduler.Features.Secretary.Authenticate
{
    public class AuthenticateSecretaryQueryHandler (IUnitOfWork unitOfWork, IPasswordHasherService passwordHasherService, ITokenService tokenService)
        : IQueryHandler<AuthenticateSecretaryQuery, LoginSecretaryResponseDTO>
    {
        public async Task<LoginSecretaryResponseDTO> Handle
            (AuthenticateSecretaryQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var secretaryRepository = unitOfWork.LoginRepository;
                var user = await secretaryRepository.GetByUsername(query.Username, cancellationToken)
                    ?? throw new KeyNotFoundException("Usuário não existe");
                var authenticatedUser = passwordHasherService.Verify(query.Password, user.HashedPassword);

                if (authenticatedUser == false) throw new UnauthorizedAccessException("Usuário ou senha inválidos");

                return GenerateToken(new LoginSecretaryResponseDTO()
                {
                    Id = user.Id,
                    Username = user.Username,
                    Name = user.Name,
                    Role = user.Role.ToString(),
                });
            }
            catch (Exception ex)
            {
                throw new Exception("Error while authenticating Secretary", ex);
            }
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
