using AppointmentScheduler.Commands.Appointment;
using AppointmentScheduler.Commands.Doctor;
using AppointmentScheduler.Commands.Patient;
using AppointmentScheduler.Commands.Request;
using AppointmentScheduler.Commands.Secretary;
using AppointmentScheduler.Commands.Specialty;
using AppointmentScheduler.Common;
using AppointmentScheduler.Configurations;
using AppointmentScheduler.Domain.Entities;
using AppointmentScheduler.Domain.Interfaces;
using AppointmentScheduler.Extensions;
using AppointmentScheduler.Infraestructure.Data;
using AppointmentScheduler.Services.Contract;
using AppointmentScheduler.Services.Implementation;
using System.Text.Json.Serialization;

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
[JsonSerializable(typeof(ScheduleAppointmentCommand))]
[JsonSerializable(typeof(CreateDoctorCommand))]
[JsonSerializable(typeof(CreatePatientCommand))]
[JsonSerializable(typeof(CreateRequestCommand))]
[JsonSerializable(typeof(CreateSecretaryCommand))]
[JsonSerializable(typeof(CreateSpecialtyCommand))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{
}