namespace AppointmentScheduler.Application.Queries.Secretary
{
    public class GetSecretaryByIdQueryHandler (IUnitOfWork unitOfWork)
        : IQueryHandler<GetSecretaryByIdQuery, Domain.Entities.Secretary>
    {
        public async Task<Domain.Entities.Secretary> Handle
            (GetSecretaryByIdQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var secretaryRepository = unitOfWork.GetRepository<Domain.Entities.Secretary>();
                return await secretaryRepository.GetByIdAsync(query.Id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while getting Secretary", ex);
            }
        }
    }
}
