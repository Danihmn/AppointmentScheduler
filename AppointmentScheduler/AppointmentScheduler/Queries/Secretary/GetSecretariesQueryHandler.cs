namespace AppointmentScheduler.Queries.Secretary
{
    public class GetSecretariesQueryHandler (IUnitOfWork unitOfWork) :
        IQueryHandler<GetSecretariesQuery, IEnumerable<Domain.Entities.Secretary>>
    {
        public async Task<IEnumerable<Domain.Entities.Secretary>> Handle
            (GetSecretariesQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var secretaryRepository = unitOfWork.GetRepository<Domain.Entities.Secretary>();
                return await secretaryRepository.GetAllAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while getting Secretaries", ex);
            }
        }
    }
}
