namespace AppointmentScheduler.Application.Queries.Doctor
{
    public class GetDoctorsQueryHandler (IUnitOfWork unitOfWork, IMapper mapper)
        : IQueryHandler<GetDoctorsQuery, IEnumerable<DoctorResponseDTO>>
    {
        public async Task<IEnumerable<DoctorResponseDTO>> Handle
            (GetDoctorsQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var doctorRepository = await unitOfWork.DoctorRepository.GetAllWithDetailAsync(cancellationToken);

                return mapper.Map<IEnumerable<DoctorResponseDTO>>(doctorRepository);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while getting Doctors", ex);
            }
        }
    }
}
