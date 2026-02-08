namespace AppointmentScheduler.Configurations
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection MapServices (this IServiceCollection services)
        {
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IRequestService, RequestService>();
            services.AddScoped<ISecretaryService, SecretaryService>();
            services.AddScoped<ISpecialtyService, SpecialtyService>();

            return services;
        }
    }
}
