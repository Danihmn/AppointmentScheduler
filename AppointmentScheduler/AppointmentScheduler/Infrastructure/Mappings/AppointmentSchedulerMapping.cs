namespace AppointmentScheduler.Infrastructure.Mappings
{
    public class AppointmentSchedulerMapping : IRegister
    {
        public void Register (TypeAdapterConfig config)
        {
            config.NewConfig<Appointment, AppointmentResponseDTO>();
            config.NewConfig<Doctor, DoctorResponseDTO>();
            config.NewConfig<Patient, PatientResponseDTO>();
            config.NewConfig<Request, RequestResponseDTO>();
            config.NewConfig<Secretary, SecretaryResponseDTO>();
            config.NewConfig<Specialty, SpecialtyResponseDTO>();
        }
    }
}
