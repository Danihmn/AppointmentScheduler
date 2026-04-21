namespace AppointmentScheduler.Features.Secretary.Create
{
    public class CreateSecretaryCommandValidator : AbstractValidator<CreateSecretaryCommand>
    {
        public CreateSecretaryCommandValidator ()
        {
            RuleFor(secretary => secretary.Username)
                .NotEmpty().WithMessage("O nome de usuário é obrigatório.")
                .MaximumLength(40).WithMessage("O nome de usuário não pode exceder 40 caracteres.");

            RuleFor(secretary => secretary.Password)
                .NotEmpty().WithMessage("A senha é obrigatória.")
                .MinimumLength(6).WithMessage("A senha deve ter no mínimo 6 caracteres.")
                .MaximumLength(20).WithMessage("A senha não pode exceder 20 caracteres.");

            RuleFor(secretary => secretary.Name)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .MaximumLength(200).WithMessage("O nome não pode exceder 200 caracteres.");

            RuleFor(secretary => secretary.Cpf)
                .NotEmpty().WithMessage("O CPF é obrigatório.")
                .Matches(@"^(?:\d{3}\.\d{3}\.\d{3}-\d{2}|\d{11})$").WithMessage("O CPF deve conter apenas números.");

            RuleFor(secretary => secretary.PhoneNumber)
                .NotEmpty().WithMessage("O número de telefone é obrigatório.")
                .Matches(@"^\(?([1-9]{2})\)? ?(?:9[0-9]|[2-8])[0-9]{3}\-?[0-9]{4}$")
                .WithMessage("O número de telefone está em um formato inválido.");

            RuleFor(secretary => secretary.Email)
                .NotEmpty().WithMessage("O email é obrigatório.")
                .MaximumLength(254).WithMessage("O email não pode exceder 254 caracteres.")
                .EmailAddress().WithMessage("O email deve ser um endereço de email válido.");

            RuleFor(secretary => secretary.HiringDate)
                .NotEmpty().WithMessage("A data de contratação é obrigatória.")
                .LessThanOrEqualTo(DateTime.Today).WithMessage("A data de contratação não pode ser no futuro.");

            RuleFor(secretary => secretary.IsActive)
                .NotNull().WithMessage("O status de ativo é obrigatório.");

            RuleFor(secretary => secretary.Role)
                .NotNull().WithMessage("O papel é obrigatório.");
        }
    }
}
