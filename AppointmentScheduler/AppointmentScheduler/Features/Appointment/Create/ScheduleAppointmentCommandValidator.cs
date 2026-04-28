namespace AppointmentScheduler.Features.Appointment.Create
{
    public class ScheduleAppointmentCommandValidator : AbstractValidator<ScheduleAppointmentCommand>
    {
        public ScheduleAppointmentCommandValidator ()
        {
            RuleFor(appointment => appointment.Date)
                .NotNull().WithMessage("A data da consulta é obrigatória.")
                .GreaterThan(DateTime.Now).WithMessage("A data da consulta deve ser no futuro.");

            RuleFor(appointment => appointment.Notes)
                .MaximumLength(250).WithMessage("As notas da consulta não podem exceder 250 caracteres.");

            RuleFor(appointment => appointment.RequestId)
                .NotNull().WithMessage("O ID da solicitação é obrigatório.")
                .GreaterThan(0).WithMessage("O ID da solicitação deve ser um valor positivo.");

            RuleFor(appointment => appointment.DoctorId)
                .NotNull().WithMessage("O ID do médico é obrigatório.")
                .GreaterThan(0).WithMessage("O ID do médico deve ser um valor positivo.");
        }
    }
}
