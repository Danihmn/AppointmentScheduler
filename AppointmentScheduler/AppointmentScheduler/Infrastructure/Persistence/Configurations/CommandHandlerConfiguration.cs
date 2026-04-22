namespace AppointmentScheduler.Infrastructure.Persistence.Configurations
{
    public static class CommandHandlerConfiguration
    {
        public static IServiceCollection MapCommandHandlers (this IServiceCollection services)
        {
            services.AddScoped<ICommandHandler<ScheduleAppointmentCommand, ApiResponse<AppointmentResponseDTO>>, ScheduleAppointmentCommandHandler>();
            services.AddScoped<IValidator<ScheduleAppointmentCommand>, ScheduleAppointmentCommandValidator>();
            services.AddScoped<ICommandHandler<CreateSpecialtyCommand, ApiResponse<SpecialtyResponseDTO>>, CreateSpecialtyCommandHandler>();
            services.AddScoped<IValidator<CreateSpecialtyCommand>, CreateSpecialtyCommandValidator>();
            services.AddScoped<ICommandHandler<CreatePatientCommand, ApiResponse<PatientResponseDTO>>, CreatePatientCommandHandler>();
            services.AddScoped<IValidator<CreatePatientCommand>, CreatePatientCommandValidator>();
            services.AddScoped<ICommandHandler<CreateDoctorCommand, ApiResponse<DoctorResponseDTO>>, CreateDoctorCommandHandler>();
            services.AddScoped<IValidator<CreateDoctorCommand>, CreateDoctorCommandValidator>();
            services.AddScoped<ICommandHandler<CreateSecretaryCommand, ApiResponse<SecretaryResponseDTO>>, CreateSecretaryCommandHandler>();
            services.AddScoped<IValidator<CreateSecretaryCommand>, CreateSecretaryCommandValidator>();
            services.AddScoped<ICommandHandler<CreateRequestCommand, ApiResponse<RequestResponseDTO>>, CreateRequestCommandHandler>();
            services.AddScoped<IValidator<CreateRequestCommand>, CreateRequestCommandValidator>();

            services.AddScoped<ICommandHandler<UpdateAppointmentCommand, ApiResponse<AppointmentResponseDTO>>, UpdateAppointmentCommandHandler>();
            services.AddScoped<IValidator<UpdateAppointmentCommand>, UpdateAppointmentCommandValidator>();
            services.AddScoped<ICommandHandler<UpdateDoctorCommand, ApiResponse<DoctorResponseDTO>>, UpdateDoctorCommandHandler>();
            services.AddScoped<IValidator<UpdateDoctorCommand>, UpdateDoctorCommandValidator>();
            services.AddScoped<ICommandHandler<UpdatePatientCommand, ApiResponse<PatientResponseDTO>>, UpdatePatientCommandHandler>();
            services.AddScoped<IValidator<UpdatePatientCommand>, UpdatePatientCommandValidator>();
            services.AddScoped<ICommandHandler<UpdateSecretaryCommand, ApiResponse<SecretaryResponseDTO>>, UpdateSecretaryCommandHandler>();
            services.AddScoped<IValidator<UpdateSecretaryCommand>, UpdateSecretaryCommandValidator>();
            services.AddScoped<ICommandHandler<UpdateSpecialtyCommand, ApiResponse<SpecialtyResponseDTO>>, UpdateSpecialtyCommandHandler>();
            services.AddScoped<IValidator<UpdateSpecialtyCommand>, UpdateSpecialtyCommandValidator>();
            services.AddScoped<ICommandHandler<UpdateRequestCommand, ApiResponse<RequestResponseDTO>>, UpdateRequestCommandHandler>();
            services.AddScoped<IValidator<UpdateRequestCommand>, UpdateRequestCommandValidator>();

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
