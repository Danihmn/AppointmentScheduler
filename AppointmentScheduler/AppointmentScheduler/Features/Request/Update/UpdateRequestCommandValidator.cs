namespace AppointmentScheduler.Features.Request.Update
{
    public class UpdateRequestCommandValidator : AbstractValidator<UpdateRequestCommand>
    {
        public UpdateRequestCommandValidator ()
        {
            RuleFor(request => request.Id)
                .NotEmpty().WithMessage("O ID da solicitação é obrigatório.")
                .GreaterThan(0).WithMessage("O ID da solicitação deve ser um número positivo.");

            RuleFor(request => request.Status)
                .NotEmpty().WithMessage("O status é obrigatório.")
                .Equal(ERequestStatus.Pending).WithMessage("O status deve ser 'Pending' para novas solicitações.");

            RuleFor(request => request.Type)
                .NotEmpty().WithMessage("O tipo de solicitação é obrigatório.")
                .IsInEnum().WithMessage("O tipo de solicitação deve ser um valor válido.")
                .Equal(ERequestType.Scheduling).WithMessage("O tipo de solicitação deve ser de reagendamento para novas solicitações.");

            RuleFor(request => request.Description)
                .NotEmpty().WithMessage("A descrição é obrigatória.")
                .MaximumLength(600).WithMessage("A descrição deve ter no máximo 600 caracteres.");

            RuleFor(request => request.Notes)
                .MaximumLength(500).WithMessage("As notas devem ter no máximo 500 caracteres.");

            RuleFor(request => request.Priority)
                .NotEmpty().WithMessage("A prioridade é obrigatória.")
                .IsInEnum().WithMessage("A prioridade deve ser um valor válido.");

            RuleFor(request => request.PatientId)
                .NotEmpty().WithMessage("O ID do paciente é obrigatório.")
                .GreaterThan(0).WithMessage("O ID do paciente deve ser um número positivo.");

            RuleFor(request => request.ProcessedBySecretaryId)
                .GreaterThan(0).WithMessage("O ID do secretário processador deve ser um número positivo.")
                .GreaterThan(0).WithMessage("O ID da secretária processadora deve ser um número positivo.");

            RuleFor(request => request.SpecialtyId)
                .NotEmpty().WithMessage("O ID da especialidade é obrigatório.")
                .GreaterThan(0).WithMessage("O ID da especialidade deve ser um número positivo.");
        }
    }
}
