using AppointmentScheduler.Features.Appointment.Get;
using AppointmentScheduler.Features.Appointment.Get.GetAll;
using AppointmentScheduler.Features.Appointment.Get.GetById;
using AppointmentScheduler.Features.Common.CQRS;
using AppointmentScheduler.Features.Doctor.Get;
using AppointmentScheduler.Features.Doctor.Get.GetAll;
using AppointmentScheduler.Features.Doctor.Get.GetById;
using AppointmentScheduler.Features.Patient.Get;
using AppointmentScheduler.Features.Patient.Get.GetAll;
using AppointmentScheduler.Features.Patient.Get.GetById;
using AppointmentScheduler.Features.Request.Get;
using AppointmentScheduler.Features.Request.Get.GetAll;
using AppointmentScheduler.Features.Request.Get.GetById;
using AppointmentScheduler.Features.Secretary.Authenticate;
using AppointmentScheduler.Features.Secretary.Get;
using AppointmentScheduler.Features.Secretary.Get.GetAll;
using AppointmentScheduler.Features.Secretary.Get.GetById;
using AppointmentScheduler.Features.Specialty.Get;
using AppointmentScheduler.Features.Specialty.Get.GetAll;
using AppointmentScheduler.Features.Specialty.Get.GetById;

namespace AppointmentScheduler.Infraestructure.Persistence.Configurations
{
    public static class QueryHandlerConfiguration
    {
        public static IServiceCollection MapQueryHandlers (this IServiceCollection services)
        {
            services
                .AddScoped<IQueryHandler<GetAppointmentsQuery, IEnumerable<AppointmentResponseDTO>>, GetAppointmentsQueryHandler>();
            services
                .AddScoped<IQueryHandler<GetAppointmentByIdQuery, AppointmentResponseDTO>, GetAppointmentByIdQueryHandler>();
            services.AddScoped<IQueryHandler<GetDoctorsQuery, IEnumerable<DoctorResponseDTO>>, GetDoctorsQueryHandler>();
            services.AddScoped<IQueryHandler<GetDoctorByIdQuery, DoctorResponseDTO>, GetDoctorByIdQueryHandler>();
            services
                .AddScoped<IQueryHandler<GetPatientsQuery, IEnumerable<PatientResponseDTO>>, GetPatientsQueryHandler>();
            services.AddScoped<IQueryHandler<GetPatientByIdQuery, PatientResponseDTO>, GetPatientByIdQueryHandler>();
            services
                .AddScoped<IQueryHandler<GetRequestsQuery, IEnumerable<RequestResponseDTO>>, GetRequestsQueryHandler>();
            services.AddScoped<IQueryHandler<GetRequestByIdQuery, RequestResponseDTO>, GetRequestByIdQueryHandler>();
            services
                .AddScoped<IQueryHandler<GetSecretariesQuery, IEnumerable<SecretaryResponseDTO>>, GetSecretariesQueryHandler>();
            services
                .AddScoped<IQueryHandler<GetSecretaryByIdQuery, SecretaryResponseDTO>, GetSecretaryByIdQueryHandler>();
            services
                .AddScoped<IQueryHandler<GetSpecialtiesQuery, IEnumerable<SpecialtyResponseDTO>>, GetSpecialtiesQueryHandler>();
            services.AddScoped<IQueryHandler<GetSpecialtyByIdQuery, SpecialtyResponseDTO>, GetSpecialtyByIdQueryHandler>();
            services
                .AddScoped<IQueryHandler<AuthenticateSecretaryQuery, LoginSecretaryResponseDTO>, AuthenticateSecretaryQueryHandler>();

            return services;
        }
    }
}
