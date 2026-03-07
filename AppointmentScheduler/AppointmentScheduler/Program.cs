namespace AppointmentScheduler;

public class Program
{
    public static void Main (string[] args)
    {
        var builder = WebApplication.CreateSlimBuilder(args);

        builder.Services.AddMapsterConfiguration();

        builder.Services.AddDatabaseConfiguration(builder.Configuration);

        builder.Services.AddAuthenticationConfiguration();

        builder.Services.AddAuthorization();

        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

        builder.Services.AddScoped<TokenConfiguration>();
        builder.Services.AddScoped<ITokenService, TokenService>();

        builder.Services.AddScoped<IPasswordHasherService, PasswordHasherService>();

        builder.Services.MapCommandHandlers();
        builder.Services.MapQueryHandlers();

        builder.Services.MapServices();

        builder.Services.ConfigureHttpJsonOptions(options =>
        {
            options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
        });

        builder.Services.AddOpenApi();

        var app = builder.Build();
        var isDevelopment = app.Environment.IsDevelopment();

        if (isDevelopment)
            app.MapOpenApi();

        if (!isDevelopment)
            app.UseHttpsRedirection();

        app.UseAuthentication();

        app.UseAuthorization();

        app.MapEndpoints();

        app.UseScalarDocumentation();

        var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";

        app.Run($"http://*:{port}");
    }
}

[JsonSerializable(typeof(AppointmentResponseDTO))]
[JsonSerializable(typeof(DoctorResponseDTO))]
[JsonSerializable(typeof(PatientResponseDTO))]
[JsonSerializable(typeof(RequestResponseDTO))]
[JsonSerializable(typeof(SecretaryResponseDTO))]
[JsonSerializable(typeof(SpecialtyResponseDTO))]
[JsonSerializable(typeof(LoginSecretaryResponseDTO))]
[JsonSerializable(typeof(GetAppointmentsQuery))]
[JsonSerializable(typeof(GetAppointmentByIdQuery))]
[JsonSerializable(typeof(ScheduleAppointmentCommand))]
[JsonSerializable(typeof(GetDoctorsQuery))]
[JsonSerializable(typeof(GetDoctorByIdQuery))]
[JsonSerializable(typeof(GetPatientsQuery))]
[JsonSerializable(typeof(GetPatientByIdQuery))]
[JsonSerializable(typeof(GetRequestsQuery))]
[JsonSerializable(typeof(GetRequestByIdQuery))]
[JsonSerializable(typeof(GetSecretariesQuery))]
[JsonSerializable(typeof(GetSecretaryByIdQuery))]
[JsonSerializable(typeof(GetSecretariesQuery))]
[JsonSerializable(typeof(GetSpecialtyByIdQuery))]
[JsonSerializable(typeof(CreateDoctorCommand))]
[JsonSerializable(typeof(CreatePatientCommand))]
[JsonSerializable(typeof(CreateRequestCommand))]
[JsonSerializable(typeof(CreateSecretaryCommand))]
[JsonSerializable(typeof(CreateSpecialtyCommand))]
internal partial class AppJsonSerializerContext : JsonSerializerContext { }