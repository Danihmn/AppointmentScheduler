namespace AppointmentScheduler.Features.Specialty.Create
{
    public class CreateSpecialtyCommandValidator : AbstractValidator<CreateSpecialtyCommand>
    {
        public CreateSpecialtyCommandValidator ()
        {
            RuleFor(specialty => specialty.Description)
                .NotEmpty().WithMessage("A descrição é obrigatória.")
                .MaximumLength(250).WithMessage("A descrição deve conter no máximo 250 caracteres.");

            RuleFor(specialty => specialty.IsActive)
                .NotNull().WithMessage("O status de ativo é obrigatório.")
                .Equal(true).WithMessage("A especialidade deve ser ativa no momento da criação.");
        }
    }
}
