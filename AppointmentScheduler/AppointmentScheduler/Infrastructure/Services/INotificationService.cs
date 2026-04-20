namespace AppointmentScheduler.Infrastructure.Services
{
    public interface INotificationService
    {
        Task NotifyAppointmentCreated (string secretaryName, string patientName, DateTime date, string doctorName);
        Task NotifyAppointmentUpdated (int id, string secretaryName, string patientName, DateTime date, string doctorName);
        Task NotifyAppointmentDeleted (int id, string secretaryName);
    }
}
