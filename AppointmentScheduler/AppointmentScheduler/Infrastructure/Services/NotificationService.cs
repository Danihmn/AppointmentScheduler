namespace AppointmentScheduler.Infrastructure.Services
{
    public class NotificationService (IHubContext<NotificationHub> hubContext) : INotificationService
    {
        #region Appointment Notifications
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
        #endregion

        #region Specialty Notifications
        public Task NotifySpecialtyCreated (string specialtyName)
        {
            var msg = $"A especialidade {specialtyName} foi criada.";
            return hubContext.Clients.All.SendAsync("ReceiveNotification", msg);
        }

        public Task NotifySpecialtyUpdated (int id, string specialtyName)
        {
            var msg = $"A especialidade #{id} foi atualizada para {specialtyName}.";
            return hubContext.Clients.All.SendAsync("ReceiveNotification", msg);
        }

        public Task NotifySpecialtyDeleted (int id, string specialtyName)
        {
            var msg = $"A especialidade #{id} '({specialtyName})' foi removida.";
            return hubContext.Clients.All.SendAsync("ReceiveNotification", msg);
        }
        #endregion
    }
}
