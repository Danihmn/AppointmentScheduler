namespace AppointmentScheduler;

public class Program
{
    public static async Task Main (string[] args)
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

        builder.Services.ConfigureHttpJsonOptions(options =>
        {
            options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
        });

        builder.Services.AddProblemDetails();
        builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

        builder.Services.AddOpenApi();

        var app = builder.Build();
        var isDevelopment = app.Environment.IsDevelopment();

        await app.SeedDatabaseAsync();

        if (isDevelopment)
            app.MapOpenApi();

        if (!isDevelopment)
            app.UseHttpsRedirection();

        app.UseExceptionHandler();

        app.UseAuthentication();

        app.UseAuthorization();

        app.MapEndpoints();

        app.UseScalarDocumentation();

        var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";

        app.Run($"http://*:{port}");
    }
}

[JsonSerializable(typeof(AppointmentResponseDTO))]
[JsonSerializable(typeof(IEnumerable<AppointmentResponseDTO>))]
[JsonSerializable(typeof(DoctorResponseDTO))]
[JsonSerializable(typeof(IEnumerable<DoctorResponseDTO>))]
[JsonSerializable(typeof(PatientResponseDTO))]
[JsonSerializable(typeof(IEnumerable<PatientResponseDTO>))]
[JsonSerializable(typeof(RequestResponseDTO))]
[JsonSerializable(typeof(IEnumerable<RequestResponseDTO>))]
[JsonSerializable(typeof(SecretaryResponseDTO))]
[JsonSerializable(typeof(IEnumerable<SecretaryResponseDTO>))]
[JsonSerializable(typeof(SpecialtyResponseDTO))]
[JsonSerializable(typeof(IEnumerable<SpecialtyResponseDTO>))]
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
[JsonSerializable(typeof(GetSpecialtiesQuery))]
[JsonSerializable(typeof(GetSpecialtyByIdQuery))]
[JsonSerializable(typeof(CreateDoctorCommand))]
[JsonSerializable(typeof(CreatePatientCommand))]
[JsonSerializable(typeof(CreateRequestCommand))]
[JsonSerializable(typeof(CreateSecretaryCommand))]
[JsonSerializable(typeof(CreateSpecialtyCommand))]
[JsonSerializable(typeof(Appointment))]
[JsonSerializable(typeof(Doctor))]
[JsonSerializable(typeof(Patient))]
[JsonSerializable(typeof(Request))]
[JsonSerializable(typeof(Secretary))]
[JsonSerializable(typeof(Specialty))]
internal partial class AppJsonSerializerContext : JsonSerializerContext { }
