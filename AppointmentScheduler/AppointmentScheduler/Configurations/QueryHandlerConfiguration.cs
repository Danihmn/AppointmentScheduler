namespace AppointmentScheduler.Configurations
{
    public static class QueryHandlerConfiguration
    {
        public static IServiceCollection MapQueryHandlers (this IServiceCollection services)
        {
            services
            .AddScoped<IQueryHandler<GetAppointmentsQuery, IEnumerable<AppointmentResponseDTO>>, GetAppointmentsQueryHandler>();
            services.AddScoped<IQueryHandler<GetAppointmentByIdQuery, Appointment>, GetAppointmentByIdQueryHandler>();
            services.AddScoped<IQueryHandler<GetDoctorsQuery, IEnumerable<Doctor>>, GetDoctorsQueryHandler>();
            services.AddScoped<IQueryHandler<GetDoctorByIdQuery, Doctor>, GetDoctorByIdQueryHandler>();
            services.AddScoped<IQueryHandler<GetPatientsQuery, IEnumerable<Patient>>, GetPatientsQueryHandler>();
            services.AddScoped<IQueryHandler<GetPatientByIdQuery, Patient>, GetPatientByIdQueryHandler>();
            services.AddScoped<IQueryHandler<GetRequestsQuery, IEnumerable<Request>>, GetRequestsQueryHandler>();
            services.AddScoped<IQueryHandler<GetRequestByIdQuery, Request>, GetRequestByIdQueryHandler>();
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
