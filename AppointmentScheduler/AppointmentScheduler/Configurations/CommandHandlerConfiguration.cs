namespace AppointmentScheduler.Configurations
{
    public static class CommandHandlerConfiguration
    {
        public static IServiceCollection MapCommandHandlers (this IServiceCollection services)
        {
            services
            .AddScoped<ICommandHandler<ScheduleAppointmentCommand, Appointment>, ScheduleAppointmentCommandHandler>();
            services.AddScoped<ICommandHandler<CreateSpecialtyCommand, Specialty>, CreateSpecialtyCommandHandler>();
            services.AddScoped<ICommandHandler<CreatePatientCommand, Patient>, CreatePatientCommandHandler>();
            services.AddScoped<ICommandHandler<CreateDoctorCommand, Doctor>, CreateDoctorCommandHandler>();
            services.AddScoped<ICommandHandler<CreateSecretaryCommand, Secretary>, CreateSecretaryCommandHandler>();
            services.AddScoped<ICommandHandler<CreateRequestCommand, Request>, CreateRequestCommandHandler>();

            return services;
        }
    }
}
