namespace AppointmentScheduler.Configurations
{
    public static class QueryHandlerConfiguration
    {
        public static IServiceCollection MapQueryHandlers (this IServiceCollection services)
        {
            services
                .AddScoped<IQueryHandler<GetAppointmentsQuery, IEnumerable<AppointmentResponseDTO>>, GetAppointmentsQueryHandler>();
            services
                .AddScoped<IQueryHandler<GetAppointmentByIdQuery, AppointmentResponseDTO>, GetAppointmentByIdQueryHandler>();
            services.AddScoped<IQueryHandler<GetDoctorsQuery, IEnumerable<DoctorResponseDTO>>, GetDoctorsQueryHandler>();
            services.AddScoped<IQueryHandler<GetDoctorByIdQuery, DoctorResponseDTO>, GetDoctorByIdQueryHandler>();
            services
                .AddScoped<IQueryHandler<GetPatientsQuery, IEnumerable<PatientResponseDTO>>, GetPatientsQueryHandler>();
            services.AddScoped<IQueryHandler<GetPatientByIdQuery, PatientResponseDTO>, GetPatientByIdQueryHandler>();
            services
                .AddScoped<IQueryHandler<GetRequestsQuery, IEnumerable<RequestResponseDTO>>, GetRequestsQueryHandler>();
            services.AddScoped<IQueryHandler<GetRequestByIdQuery, RequestResponseDTO>, GetRequestByIdQueryHandler>();
            services
                .AddScoped<IQueryHandler<GetSecretariesQuery, IEnumerable<Secretary>>, GetSecretariesQueryHandler>();
            services.AddScoped<IQueryHandler<GetSecretaryByIdQuery, Secretary>, GetSecretaryByIdQueryHandler>();
            services
                .AddScoped<IQueryHandler<GetSpecialtiesQuery, IEnumerable<Specialty>>, GetSpecialtiesQueryHandler>();
            services.AddScoped<IQueryHandler<GetSpecialtyByIdQuery, Specialty>, GetSpecialtyByIdQueryHandler>();

            return services;
        }
    }
}
