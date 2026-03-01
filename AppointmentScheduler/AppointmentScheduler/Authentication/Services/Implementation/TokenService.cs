namespace AppointmentScheduler.Authentication.Services.Implementation
{
    public class TokenService : ITokenService
    {
        public string Generate (LoginSecretaryResponseDTO secretary)
        {
            var handler = new JwtSecurityTokenHandler();

            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenConfiguration.PrivateKey)),
                SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = GenerateClaims(secretary),
                SigningCredentials = credentials,
                Expires = DateTime.UtcNow.AddHours(2)
            };

            var token = handler.CreateToken(tokenDescriptor);

            return handler.WriteToken(token);
        }

        public static ClaimsIdentity GenerateClaims (LoginSecretaryResponseDTO secretary)
        {
            var claimsIdentity = new ClaimsIdentity();

            claimsIdentity.AddClaim(new(ClaimTypes.Name, secretary.Username));

            foreach (var role in secretary.Roles)
                claimsIdentity.AddClaim(new(ClaimTypes.Role, role));

            return claimsIdentity;
        }
    }
}
