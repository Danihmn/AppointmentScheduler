namespace AppointmentScheduler.Features.Patient.Update
{
    public class UpdatePatientCommandValidator : AbstractValidator<UpdatePatientCommand>
    {
        public UpdatePatientCommandValidator ()
        {
            RuleFor(patient => patient.Id)
                .NotEmpty().WithMessage("O ID do paciente é obrigatório.")
                .GreaterThan(0).WithMessage("O ID do paciente deve ser um número positivo.");

            RuleFor(patient => patient.Name)
                .NotEmpty().WithMessage("O nome do paciente é obrigatório.")
                .MaximumLength(200).WithMessage("O nome do paciente deve ter no máximo 200 caracteres.");

            RuleFor(patient => patient.Cpf)
                .NotEmpty().WithMessage("O CPF do paciente é obrigatório.")
                .Matches(@"^\d{3}\.\d{3}\.\d{3}\-\d{2}$").WithMessage("O CPF do paciente está em um formato inválido.");

            RuleFor(patient => patient.PhoneNumber)
                .NotEmpty().WithMessage("O número de telefone do paciente é obrigatório.")
                .Matches(@"^\(?([1-9]{2})\)? ?(?:9[0-9]|[2-8])[0-9]{3}\-?[0-9]{4}$")
                .WithMessage("O número de telefone do paciente está em um formato inválido.");

            RuleFor(patient => patient.Email)
                .NotEmpty().WithMessage("O email do paciente é obrigatório.")
                .EmailAddress().WithMessage("O email do paciente deve ser um endereço de email válido.");

            RuleFor(patient => patient.Gender)
                .NotEmpty().WithMessage("O gênero do paciente é obrigatório.");

            RuleFor(patient => patient.Notes)
                .MaximumLength(500).WithMessage("As notas do paciente devem ter no máximo 500 caracteres.");
        }
    }
}
