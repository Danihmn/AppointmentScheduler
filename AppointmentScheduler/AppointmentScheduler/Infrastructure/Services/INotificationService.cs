namespace AppointmentScheduler.Infrastructure.Services
{
    public interface INotificationService
    {
        Task NotifyAppointmentCreated (string patientName, DateTime date, string doctorName);
        Task NotifyAppointmentUpdated (int id, string patientName, DateTime date, string doctorName);
        Task NotifyAppointmentDeleted (int id);
        Task NotifySpecialtyCreated (string specialtyName);
        Task NotifySpecialtyUpdated (int id, string specialtyName);
        Task NotifySpecialtyDeleted (int id, string specialtyName);
    }
}
