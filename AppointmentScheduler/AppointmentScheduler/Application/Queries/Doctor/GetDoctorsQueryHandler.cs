namespace AppointmentScheduler.Application.Queries.Doctor
{
    public class GetDoctorsQueryHandler (IUnitOfWork unitOfWork)
        : IQueryHandler<GetDoctorsQuery, IEnumerable<Domain.Entities.Doctor>>
    {
        public async Task<IEnumerable<Domain.Entities.Doctor>> Handle
            (GetDoctorsQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var doctorRepository = unitOfWork.GetRepository<Domain.Entities.Doctor>();
                return await doctorRepository.GetAllAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while getting Doctors", ex);
            }
        }
    }
}
