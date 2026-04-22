namespace AppointmentScheduler.Features.Appointment.Update
{
    public class UpdateAppointmentCommandValidator : AbstractValidator<UpdateAppointmentCommand>
    {
        public UpdateAppointmentCommandValidator ()
        {
            RuleFor(appointment => appointment.Id)
                .NotNull().WithMessage("O ID da consulta é obrigatório.")
                .GreaterThan(0).WithMessage("O ID da consulta deve ser um valor positivo.");

            RuleFor(appointment => appointment.Date)
                    .NotNull().WithMessage("A data da consulta é obrigatória.");

            RuleFor(appointment => appointment.Status)
                .NotNull().WithMessage("O status da consulta é obrigatório.")
                .IsInEnum().WithMessage("O status da consulta deve ser um valor válido.");

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
