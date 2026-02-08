namespace AppointmentScheduler.Application.Queries.Specialty
{
    public class GetSpecialtyByIdQueryHandler (IUnitOfWork unitOfWork, IMapper mapper)
        : IQueryHandler<GetSpecialtyByIdQuery, SpecialtyResponseDTO>
    {
        public async Task<SpecialtyResponseDTO> Handle
            (GetSpecialtyByIdQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var specialtyRepoitory
                    = await unitOfWork.SpecialtyRepository.GetByIdWithDetailsAsync(query.Id, cancellationToken);

                return specialtyRepoitory == null ? throw new Exception()
                    : mapper.Map<SpecialtyResponseDTO>(specialtyRepoitory);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while getting Specialty", ex);
            }
        }
    }
}
