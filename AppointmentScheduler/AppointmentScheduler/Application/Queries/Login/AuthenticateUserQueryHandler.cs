using AppointmentScheduler.Authentication.Services.Contract;

namespace AppointmentScheduler.Application.Queries.Login
{
    public class AuthenticateUserQueryHandler (IUnitOfWork unitOfWork, IPasswordHasherService passwordHasherService)
        : IQueryHandler<AuthenticateUserQuery, LoginSecretaryResponseDTO>
    {

        public async Task<LoginSecretaryResponseDTO> Handle
            (AuthenticateUserQuery query, CancellationToken cancellationToken)
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
                    Username = user.Username,
                    Name = user.Name,
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error while authenticating Secretary", ex);
            }
        }
    }
}
