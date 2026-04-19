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

            services.AddScoped<ICommandHandler<UpdateAppointmentCommand, ApiResponse<AppointmentResponseDTO>>, UpdateAppointmentCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateDoctorCommand, ApiResponse<DoctorResponseDTO>>, UpdateDoctorCommandHandler>();
            services.AddScoped<ICommandHandler<UpdatePatientCommand, ApiResponse<PatientResponseDTO>>, UpdatePatientCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateSecretaryCommand, ApiResponse<SecretaryResponseDTO>>, UpdateSecretaryCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateSpecialtyCommand, ApiResponse<SpecialtyResponseDTO>>, UpdateSpecialtyCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateRequestCommand, ApiResponse<RequestResponseDTO>>, UpdateRequestCommandHandler>();

            services.AddScoped<ICommandHandler<DeleteAppointmentCommand, ApiResponse<AppointmentResponseDTO>>, DeleteAppointmentCommandHandler>();
            services.AddScoped<ICommandHandler<DeleteDoctorCommand, ApiResponse<DoctorResponseDTO>>, DeleteDoctorCommandHandler>();
            services.AddScoped<ICommandHandler<DeletePatientCommand, ApiResponse<PatientResponseDTO>>, DeletePatientCommandHandler>();
            services.AddScoped<ICommandHandler<DeleteSecretaryCommand, ApiResponse<SecretaryResponseDTO>>, DeleteSecretaryCommandHandler>();
            services.AddScoped<ICommandHandler<DeleteSpecialtyCommand, ApiResponse<SpecialtyResponseDTO>>, DeleteSpecialtyCommandHandler>();
            services.AddScoped<ICommandHandler<DeleteRequestCommand, ApiResponse<RequestResponseDTO>>, DeleteRequestCommandHandler>();

            return services;
        }
    }
}
