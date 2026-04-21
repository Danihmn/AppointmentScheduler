namespace AppointmentScheduler.Features.Doctor.Update
{
    public class UpdateDoctorCommandValidator : AbstractValidator<UpdateDoctorCommand>
    {
        public UpdateDoctorCommandValidator ()
        {
            RuleFor(doctor => doctor.Id)
                .NotEmpty().WithMessage("O ID do médico é obrigatório.")
                .GreaterThan(0).WithMessage("O ID do médico deve ser um número positivo.");

            RuleFor(doctor => doctor.Name)
                .NotEmpty().WithMessage("O nome do médico é obrigatório.")
                .MaximumLength(200).WithMessage("O nome do médico deve ter no máximo 200 caracteres.");

            RuleFor(doctor => doctor.Crm)
                .NotEmpty().WithMessage("O CRM do médico é obrigatório.")
                .Matches(@"^(\d{6})([P])?$").WithMessage("O CRM do médico está em um formato inválido.");

            RuleFor(doctor => doctor.PhoneNumber)
                .NotEmpty().WithMessage("O número de telefone do médico é obrigatório.")
                .Matches(@"^\(?([1-9]{2})\)? ?(?:9[0-9]|[2-8])[0-9]{3}\-?[0-9]{4}$")
                .WithMessage("O número de telefone do médico está em um formato inválido.");

            RuleFor(doctor => doctor.Email)
                .NotEmpty().WithMessage("O email do médico é obrigatório.")
                .EmailAddress().WithMessage("O email do médico deve ser um endereço de email válido.");

            RuleFor(doctor => doctor.HiringDate)
                .NotEmpty().WithMessage("A data de contratação é obrigatória.")
                .LessThanOrEqualTo(DateTime.Today).WithMessage("A data de contratação não pode ser no futuro.");

            RuleFor(doctor => doctor.SpecialtyId)
                .NotEmpty().WithMessage("A especialidade do médico é obrigatória.")
                .GreaterThan(0).WithMessage("A especialidade do médico deve ser um ID válido.");

            RuleFor(doctor => doctor.Active)
                .NotNull().WithMessage("O status de ativo do médico é obrigatório.")
                .Equal(true).WithMessage("O médico deve ser criado como ativo.");
        }
    }
}
