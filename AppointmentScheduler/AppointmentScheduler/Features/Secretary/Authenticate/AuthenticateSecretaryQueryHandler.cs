using AppointmentScheduler.Features.Common.CQRS;
using AppointmentScheduler.Infraestructure.Authentication.Services.Contract;
using AppointmentScheduler.Infraestructure.Persistence.UnifOfWork;

namespace AppointmentScheduler.Features.Secretary.Authenticate
{
    public class AuthenticateSecretaryQueryHandler (IUnitOfWork unitOfWork, IPasswordHasherService passwordHasherService)
        : IQueryHandler<AuthenticateSecretaryQuery, LoginSecretaryResponseDTO>
    {
        public async Task<LoginSecretaryResponseDTO> Handle
            (AuthenticateSecretaryQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var secretaryRepository = unitOfWork.LoginRepository;
                var user = await secretaryRepository.GetByUsername(query.Username, cancellationToken);

                if (user == null) return null;

                var authenticatedUser = passwordHasherService.Verify(query.Password, user.HashedPassword);

                if (authenticatedUser == false) return null;

                return new LoginSecretaryResponseDTO()
                {
                    Id = user.Id,
                    Username = user.Username,
                    Name = user.Name,
                    Role = user.Role.ToString(),
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error while authenticating Secretary", ex);
            }
        }
    }
}
