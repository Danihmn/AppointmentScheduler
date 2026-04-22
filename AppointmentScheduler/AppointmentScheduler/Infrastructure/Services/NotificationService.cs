namespace AppointmentScheduler.Infrastructure.Services
{
    public class NotificationService (IHubContext<NotificationHub> hubContext) : INotificationService
    {
        public Task NotifyAppointmentCreated (string patientName, DateTime date, string doctorName)
        {
            var message = $"Uma consulta para {patientName} foi agendada, para o dia {date:dd/MM/yyyy HH:mm}, Com Dr(a). {doctorName}.";
            return hubContext.Clients.All.SendAsync("ReceiveNotification", message);
        }

        public Task NotifyAppointmentUpdated (int id, string patientName, DateTime date, string doctorName)
        {
            var message = $"A consulta #{id} foi alterada para {patientName}, dia {date:dd/MM/yyyy HH:mm}, Com Dr(a). {doctorName}.";
            return hubContext.Clients.All.SendAsync("ReceiveNotification", message);
        }
        public Task NotifyAppointmentDeleted (int id)
        {
            var msg = $"A consulta #{id} foi removida";
            return hubContext.Clients.All.SendAsync("ReceiveNotification", msg);
        }
    }
}
