namespace AppointmentScheduler.Configurations
{
    public static class MapsterConfiguration
    {
        public static IServiceCollection AddMapsterConfiguration (this IServiceCollection services)
        {
            var config = new TypeAdapterConfig();
            config.Default.PreserveReference(true);

            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();
            services.AddMapster();

            return services;
        }
    }
}
