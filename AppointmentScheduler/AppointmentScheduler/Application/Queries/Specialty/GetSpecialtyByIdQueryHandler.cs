namespace AppointmentScheduler.Application.Queries.Specialty
{
    public class GetSpecialtyByIdQueryHandler (IUnitOfWork unitOfWork)
        : IQueryHandler<GetSpecialtyByIdQuery, Domain.Entities.Specialty>
    {
        public async Task<Domain.Entities.Specialty> Handle
            (GetSpecialtyByIdQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var specialtyRepoitory = unitOfWork.GetRepository<Domain.Entities.Specialty>();
                return await specialtyRepoitory.GetByIdAsync(query.Id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while getting Specialty", ex);
            }
        }
    }
}
