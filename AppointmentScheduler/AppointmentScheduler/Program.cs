using System.Text.Json.Serialization;
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

namespace AppointmentScheduler;

public class Program
{
    public static void Main(string[] args)
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

[JsonSerializable(typeof(Appointment[]))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{
}