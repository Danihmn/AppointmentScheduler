namespace AppointmentScheduler.Infrastructure.Persistence.Configurations
{
    public static class QueryHandlerConfiguration
    {
        public static IServiceCollection MapQueryHandlers (this IServiceCollection services)
        {
            services.AddScoped<IQueryHandler<GetAppointmentsQuery, ApiResponse<IEnumerable<AppointmentResponseDTO>>>, GetAppointmentsQueryHandler>();
            services.AddScoped<IQueryHandler<GetAppointmentByIdQuery, ApiResponse<AppointmentResponseDTO>>, GetAppointmentByIdQueryHandler>();
            services.AddScoped<IQueryHandler<GetDoctorsQuery, ApiResponse<IEnumerable<DoctorResponseDTO>>>, GetDoctorsQueryHandler>();
            services.AddScoped<IQueryHandler<GetDoctorByIdQuery, ApiResponse<DoctorResponseDTO>>, GetDoctorByIdQueryHandler>();
            services.AddScoped<IQueryHandler<GetPatientsQuery, ApiResponse<IEnumerable<PatientResponseDTO>>>, GetPatientsQueryHandler>();
            services.AddScoped<IQueryHandler<GetPatientByIdQuery, ApiResponse<PatientResponseDTO>>, GetPatientByIdQueryHandler>();
            services.AddScoped<IQueryHandler<GetRequestsQuery, ApiResponse<IEnumerable<RequestResponseDTO>>>, GetRequestsQueryHandler>();
            services.AddScoped<IQueryHandler<GetRequestByIdQuery, ApiResponse<RequestResponseDTO>>, GetRequestByIdQueryHandler>();
            services.AddScoped<IQueryHandler<GetSecretariesQuery, ApiResponse<IEnumerable<SecretaryResponseDTO>>>, GetSecretariesQueryHandler>();
            services.AddScoped<IQueryHandler<GetSecretaryByIdQuery, ApiResponse<SecretaryResponseDTO>>, GetSecretaryByIdQueryHandler>();
            services.AddScoped<IQueryHandler<GetSpecialtiesQuery, ApiResponse<IEnumerable<SpecialtyResponseDTO>>>, GetSpecialtiesQueryHandler>();
            services.AddScoped<IQueryHandler<GetSpecialtyByIdQuery, ApiResponse<SpecialtyResponseDTO>>, GetSpecialtyByIdQueryHandler>();
            services.AddScoped<IQueryHandler<AuthenticateSecretaryQuery, ApiResponse<LoginSecretaryResponseDTO>>, AuthenticateSecretaryQueryHandler>();

            return services;
        }
    }
}
