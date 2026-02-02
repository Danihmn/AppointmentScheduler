using AppointmentScheduler.Application.Commands.Appointment;
using AppointmentScheduler.Application.Commands.Doctor;
using AppointmentScheduler.Application.Commands.Patient;
using AppointmentScheduler.Application.Commands.Request;
using AppointmentScheduler.Application.Commands.Secretary;
using AppointmentScheduler.Application.Commands.Specialty;
using AppointmentScheduler.Application.Common;
using AppointmentScheduler.Application.Queries.Appointment;
using AppointmentScheduler.Application.Queries.Doctor;
using AppointmentScheduler.Application.Queries.Patient;
using AppointmentScheduler.Application.Queries.Request;
using AppointmentScheduler.Application.Queries.Secretary;
using AppointmentScheduler.Infraestructure.Extensions;
using AppointmentScheduler.Infraestructure.Services.Contract;
using AppointmentScheduler.Infraestructure.Services.Implementation;

namespace AppointmentScheduler;

public class Program
{
    public static void Main (string[] args)
    {
        var builder = WebApplication.CreateSlimBuilder(args);

        builder.Services.AddDatabaseConfiguration(builder.Configuration);

        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

        builder.Services
            .AddScoped<ICommandHandler<ScheduleAppointmentCommand, Appointment>, ScheduleAppointmentCommandHandler>();
        builder.Services.AddScoped<ICommandHandler<CreateSpecialtyCommand, Specialty>, CreateSpecialtyCommandHandler>();
        builder.Services.AddScoped<ICommandHandler<CreatePatientCommand, Patient>, CreatePatientCommandHandler>();
        builder.Services.AddScoped<ICommandHandler<CreateDoctorCommand, Doctor>, CreateDoctorCommandHandler>();
        builder.Services.AddScoped<ICommandHandler<CreateSecretaryCommand, Secretary>, CreateSecretaryCommandHandler>();
        builder.Services.AddScoped<ICommandHandler<CreateRequestCommand, Request>, CreateRequestCommandHandler>();

        builder.Services
            .AddScoped<IQueryHandler<GetAppointmentsQuery, IEnumerable<Appointment>>, GetAppointmentsQueryHandler>();
        builder.Services.AddScoped<IQueryHandler<GetAppointmentByIdQuery, Appointment>, GetAppointmentByIdQueryHandler>();
        builder.Services.AddScoped<IQueryHandler<GetDoctorsQuery, IEnumerable<Doctor>>, GetDoctorsQueryHandler>();
        builder.Services.AddScoped<IQueryHandler<GetDoctorByIdQuery, Doctor>, GetDoctorByIdQueryHandler>();
        builder.Services.AddScoped<IQueryHandler<GetPatientsQuery, IEnumerable<Patient>>, GetPatientsQueryHandler>();
        builder.Services.AddScoped<IQueryHandler<GetPatientByIdQuery, Patient>, GetPatientByIdQueryHandler>();
        builder.Services.AddScoped<IQueryHandler<GetRequestsQuery, IEnumerable<Request>>, GetRequestsQueryHandler>();
        builder.Services.AddScoped<IQueryHandler<GetRequestByIdQuery, Request>, GetRequestByIdQueryHandler>();
        builder.Services
            .AddScoped<IQueryHandler<GetSecretariesQuery, IEnumerable<Secretary>>, GetSecretariesQueryHandler>();
        builder.Services.AddScoped<IQueryHandler<GetSecretaryByIdQuery, Secretary>, GetSecretaryByIdQueryHandler>();

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
[JsonSerializable(typeof(CreateDoctorCommand))]
[JsonSerializable(typeof(CreatePatientCommand))]
[JsonSerializable(typeof(CreateRequestCommand))]
[JsonSerializable(typeof(CreateSecretaryCommand))]
[JsonSerializable(typeof(CreateSpecialtyCommand))]
internal partial class AppJsonSerializerContext : JsonSerializerContext { }