namespace AppointmentScheduler.Infrastructure.Services
{
    public interface INotificationService
    {
        Task NotifyAppointmentCreated (string patientName, DateTime date, string doctorName);
        Task NotifyAppointmentUpdated (int id, string patientName, DateTime date, string doctorName);
        Task NotifyAppointmentDeleted (int id);
    }
}
