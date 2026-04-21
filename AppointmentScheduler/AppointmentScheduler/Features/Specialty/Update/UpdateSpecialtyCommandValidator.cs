namespace AppointmentScheduler.Features.Specialty.Update
{
    public class UpdateSpecialtyCommandValidator : AbstractValidator<UpdateSpecialtyCommand>
    {
        public UpdateSpecialtyCommandValidator ()
        {
            RuleFor(specialty => specialty.Id)
                .NotEmpty().WithMessage("O ID é obrigatório.");

            RuleFor(specialty => specialty.Description)
                .NotEmpty().WithMessage("A descrição é obrigatória.")
                .MaximumLength(250).WithMessage("A descrição deve conter no máximo 250 caracteres.");
        }
    }
}
