using AppointmentScheduler.Infraestructure.Authentication.Configuration;

namespace AppointmentScheduler.Infraestructure.Persistence.Configurations
{
    public static class AuthenticationConfiguration
    {
        public static IServiceCollection AddAuthenticationConfiguration (this IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenConfiguration.PrivateKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            return services;
        }
    }
}
