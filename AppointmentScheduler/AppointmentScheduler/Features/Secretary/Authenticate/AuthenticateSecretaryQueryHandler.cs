namespace AppointmentScheduler.Features.Secretary.Authenticate
{
    public class AuthenticateSecretaryQueryHandler (IUnitOfWork unitOfWork, IPasswordHasherService passwordHasherService, ITokenService tokenService)
        : IQueryHandler<AuthenticateSecretaryQuery, ApiResponse<LoginSecretaryResponseDTO>>
    {
        public async Task<ApiResponse<LoginSecretaryResponseDTO>> Handle
            (AuthenticateSecretaryQuery query, CancellationToken cancellationToken)
        {
            var secretaryRepository = unitOfWork.LoginRepository;
            var user = await secretaryRepository.GetByUsername(query.Username, cancellationToken)
                ?? throw new UnauthorizedAccessException("Usuário ou senha inválidos");
            var authenticatedUser = passwordHasherService.Verify(query.Password, user.HashedPassword);

            if (authenticatedUser == false) throw new UnauthorizedAccessException("Usuário ou senha inválidos");

            return GenerateToken(new LoginSecretaryResponseDTO()
            {
                Id = user.Id,
                Username = user.Username,
                Name = user.Name,
                Role = user.Role?.ToString(),
            });
        }

        private ApiResponse<LoginSecretaryResponseDTO> GenerateToken (LoginSecretaryResponseDTO user)
        {
            var additionalClaims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new(JwtRegisteredClaimNames.UniqueName, user.Name),
            };

            user.AccessToken = tokenService.Generate(user, additionalClaims);

            var response = new ApiResponse<LoginSecretaryResponseDTO>
            {
                Success = true,
                Data = user,
                Message = "Usuário autenticado com sucesso"
            };

            return response;
        }
    }
}
