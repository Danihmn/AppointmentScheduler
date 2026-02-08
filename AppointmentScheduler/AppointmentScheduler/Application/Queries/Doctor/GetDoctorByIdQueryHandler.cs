namespace AppointmentScheduler.Application.Queries.Doctor
{
    public class GetDoctorByIdQueryHandler (IUnitOfWork unitOfWork, IMapper mapper)
        : IQueryHandler<GetDoctorByIdQuery, DoctorResponseDTO>
    {
        public async Task<DoctorResponseDTO> Handle (GetDoctorByIdQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var doctorRepository
                    = await unitOfWork.DoctorRepository.GetByIdWithDetailsAsync(query.Id, cancellationToken);

                return doctorRepository == null ? throw new Exception()
                    : mapper.Map<DoctorResponseDTO>(doctorRepository);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while getting Doctor", ex);
            }
        }
    }
}
