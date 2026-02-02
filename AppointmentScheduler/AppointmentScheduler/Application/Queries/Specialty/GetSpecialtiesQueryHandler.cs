namespace AppointmentScheduler.Application.Queries.Specialty
{
    public class GetSpecialtiesQueryHandler (IUnitOfWork unitOfWork)
        : IQueryHandler<GetSpecialtiesQuery, IEnumerable<Domain.Entities.Specialty>>
    {
        public async Task<IEnumerable<Domain.Entities.Specialty>> Handle
            (GetSpecialtiesQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var specialtyRepository = unitOfWork.GetRepository<Domain.Entities.Specialty>();
                return await specialtyRepository.GetAllAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while getting Specialties", ex);
            }
        }
    }
}
