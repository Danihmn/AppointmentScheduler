namespace AppointmentScheduler.Infrastructure.Persistence.Configurations
{
    public static class CommandHandlerConfiguration
    {
        public static IServiceCollection MapCommandHandlers (this IServiceCollection services)
        {
            services.AddScoped<ICommandHandler<ScheduleAppointmentCommand, ApiResponse<AppointmentResponseDTO>>, ScheduleAppointmentCommandHandler>();
            services.AddScoped<ICommandHandler<CreateSpecialtyCommand, ApiResponse<SpecialtyResponseDTO>>, CreateSpecialtyCommandHandler>();
            services.AddScoped<ICommandHandler<CreatePatientCommand, ApiResponse<PatientResponseDTO>>, CreatePatientCommandHandler>();
            services.AddScoped<ICommandHandler<CreateDoctorCommand, ApiResponse<DoctorResponseDTO>>, CreateDoctorCommandHandler>();
            services.AddScoped<ICommandHandler<CreateSecretaryCommand, ApiResponse<SecretaryResponseDTO>>, CreateSecretaryCommandHandler>();
            services.AddScoped<ICommandHandler<CreateRequestCommand, ApiResponse<RequestResponseDTO>>, CreateRequestCommandHandler>();

            return services;
        }
    }
}
