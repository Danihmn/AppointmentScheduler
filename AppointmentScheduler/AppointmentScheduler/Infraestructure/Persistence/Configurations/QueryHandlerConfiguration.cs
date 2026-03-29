namespace AppointmentScheduler.Infraestructure.Persistence.Configurations
{
    public static class QueryHandlerConfiguration
    {
        public static IServiceCollection MapQueryHandlers (this IServiceCollection services)
        {
            services.AddScoped<IQueryHandler<GetAppointmentsQuery, IEnumerable<AppointmentResponseDTO>>, GetAppointmentsQueryHandler>();
            services.AddScoped<IQueryHandler<GetAppointmentByIdQuery, AppointmentResponseDTO>, GetAppointmentByIdQueryHandler>();
            services.AddScoped<IQueryHandler<GetDoctorsQuery, IEnumerable<DoctorResponseDTO>>, GetDoctorsQueryHandler>();
            services.AddScoped<IQueryHandler<GetDoctorByIdQuery, DoctorResponseDTO>, GetDoctorByIdQueryHandler>();
            services.AddScoped<IQueryHandler<GetPatientsQuery, ApiResponse<IEnumerable<PatientResponseDTO>>>, GetPatientsQueryHandler>();
            services.AddScoped<IQueryHandler<GetPatientByIdQuery, ApiResponse<PatientResponseDTO>>, GetPatientByIdQueryHandler>();
            services.AddScoped<IQueryHandler<GetRequestsQuery, ApiResponse<IEnumerable<RequestResponseDTO>>>, GetRequestsQueryHandler>();
            services.AddScoped<IQueryHandler<GetRequestByIdQuery, ApiResponse<RequestResponseDTO>>, GetRequestByIdQueryHandler>();
            services.AddScoped<IQueryHandler<GetSecretariesQuery, ApiResponse<IEnumerable<SecretaryResponseDTO>>>, GetSecretariesQueryHandler>();
            services.AddScoped<IQueryHandler<GetSecretaryByIdQuery, ApiResponse<SecretaryResponseDTO>>, GetSecretaryByIdQueryHandler>();
            services.AddScoped<IQueryHandler<GetSpecialtiesQuery, IEnumerable<SpecialtyResponseDTO>>, GetSpecialtiesQueryHandler>();
            services.AddScoped<IQueryHandler<GetSpecialtyByIdQuery, SpecialtyResponseDTO>, GetSpecialtyByIdQueryHandler>();
            services.AddScoped<IQueryHandler<AuthenticateSecretaryQuery, LoginSecretaryResponseDTO>, AuthenticateSecretaryQueryHandler>();

            return services;
        }
    }
}
