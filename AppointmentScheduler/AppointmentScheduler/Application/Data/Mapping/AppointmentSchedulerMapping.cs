namespace AppointmentScheduler.Application.Data.Mapping
{
    public class AppointmentSchedulerMapping : IRegister
    {
        public void Register (TypeAdapterConfig config)
        {
            config.NewConfig<Appointment, AppointmentResponseDTO>()
                .Map(dest => dest.Status, src => src.Status.ToString())
                .Map(dest => dest.Request, src => src.Request != null ? src.Request.Adapt<RequestResponseDTO>() : null)
                .Map(dest => dest.Patient, src => src.Patient != null ? src.Patient.Adapt<PatientResponseDTO>() : null)
                .Map(dest => dest.Doctor, src => src.Doctor != null ? src.Doctor.Adapt<DoctorResponseDTO>() : null)
                .Map(dest => dest.Specialty, src => src.Specialty != null ? src.Specialty.Adapt<SpecialtyResponseDTO>() : null)
                .Map(dest => dest.Secretary, src => src.Secretary != null ? src.Secretary.Adapt<SecretaryResponseDTO>() : null);

            config.NewConfig<Doctor, DoctorResponseDTO>()
                .Map(dest => dest.Specialty, src => src.Specialty != null ? src.Specialty.Adapt<SpecialtyResponseDTO>() : null)
                .Map(dest => dest.Appointments, src => src.Appointments != null ? src.Appointments.Adapt<IEnumerable<AppointmentResponseDTO>>() : null);
        }
    }
}
