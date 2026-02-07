namespace AppointmentScheduler;

public class Program
{
    public static void Main (string[] args)
    {
        var builder = WebApplication.CreateSlimBuilder(args);

        builder.Services.AddMapster();

        builder.Services.AddScoped<IMapper, ServiceMapper>();

        builder.Services.AddDatabaseConfiguration(builder.Configuration);

        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

        builder.Services.MapCommandHandlers();
        builder.Services.MapQueryHandlers();

        builder.Services.AddScoped<IAppointmentService, AppointmentService>();
        builder.Services.AddScoped<IDoctorService, DoctorService>();
        builder.Services.AddScoped<IPatientService, PatientService>();
        builder.Services.AddScoped<IRequestService, RequestService>();
        builder.Services.AddScoped<ISecretaryService, SecretaryService>();
        builder.Services.AddScoped<ISpecialtyService, SpecialtyService>();

        builder.Services.ConfigureHttpJsonOptions(options =>
        {
            options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
        });

        builder.Services.AddOpenApi();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.MapEndpoints();

        app.UseScalarDocumentation();

        app.Run();
    }
}

[JsonSerializable(typeof(Appointment))]
[JsonSerializable(typeof(AppointmentResponseDTO))]
[JsonSerializable(typeof(Doctor))]
[JsonSerializable(typeof(Patient))]
[JsonSerializable(typeof(Request))]
[JsonSerializable(typeof(Secretary))]
[JsonSerializable(typeof(Specialty))]
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