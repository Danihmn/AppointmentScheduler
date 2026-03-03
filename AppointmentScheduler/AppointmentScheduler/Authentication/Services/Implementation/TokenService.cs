namespace AppointmentScheduler.Authentication.Services.Implementation
{
    public class TokenService : ITokenService
    {
        public string Generate (LoginSecretaryResponseDTO secretary, IEnumerable<Claim>? additionalClaims = null)
        {
            var handler = new JwtSecurityTokenHandler();

            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenConfiguration.PrivateKey)),
                SecurityAlgorithms.HmacSha256);

            var claimsIdentity = GenerateClaims(secretary);

            if (additionalClaims != null)
                claimsIdentity.AddClaims(additionalClaims);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = claimsIdentity,
                SigningCredentials = credentials,
                Expires = DateTime.UtcNow.AddHours(2)
            };

            var token = handler.CreateToken(tokenDescriptor);

            return handler.WriteToken(token);
        }

        public static ClaimsIdentity GenerateClaims (LoginSecretaryResponseDTO secretary)
        {
            var claimsIdentity = new ClaimsIdentity();

            foreach (var role in secretary.Roles)
                claimsIdentity.AddClaim(new(ClaimTypes.Role, role));

            return claimsIdentity;
        }
    }
}
