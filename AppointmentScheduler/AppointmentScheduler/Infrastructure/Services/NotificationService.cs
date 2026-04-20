namespace AppointmentScheduler.Infrastructure.Services
{
    public class NotificationService (IHubContext<NotificationHub> hubContext) : INotificationService
    {
        public Task NotifyAppointmentCreated (string secretaryName, string patientName, DateTime date, string doctorName)
        {
            var message = $"{secretaryName} agendou uma consulta para {patientName}, dia {date:dd/MM/yyyy HH:mm}, Com Dr(a). {doctorName}.";
            return hubContext.Clients.All.SendAsync("ReceiveNotification", message);
        }

        public Task NotifyAppointmentUpdated (int id, string secretaryName, string patientName, DateTime date, string doctorName)
        {
            var message = $"{secretaryName} atualizou a consulta #{id} para {patientName}, dia {date:dd/MM/yyyy HH:mm}, Com Dr(a). {doctorName}.";
            return hubContext.Clients.All.SendAsync("ReceiveNotification", message);
        }
        public Task NotifyAppointmentDeleted (int id, string secretaryName)
        {
            var msg = $"{secretaryName} removeu a consulta #{id}";
            return hubContext.Clients.All.SendAsync("ReceiveNotification", msg);
        }
    }
}
