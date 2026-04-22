namespace AppointmentScheduler.API.Exceptions;

public sealed class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync (HttpContext context, Exception ex, CancellationToken cancellationToken)
    {
        var (status, title) = ex switch
        {
            NotFoundException => (StatusCodes.Status404NotFound, "Recurso não encontrado"),
            BusinessRuleException => (StatusCodes.Status409Conflict, "Regra de negócio violada"),
            UnauthorizedAccessException => (StatusCodes.Status401Unauthorized, "Não autorizado"),
            ArgumentOutOfRangeException => (StatusCodes.Status400BadRequest, "Parâmetro inválido"),
            KeyNotFoundException => (StatusCodes.Status404NotFound, "Recurso não encontrado"),
            ValidationException => (StatusCodes.Status400BadRequest, "Validação falhou"),
            _ => (StatusCodes.Status500InternalServerError, "Erro interno do servidor")
        };

        var problemDetails = new ProblemDetails
        {
            Status = status,
            Title = title,
            Detail = ex.Message,
            Instance = context.Request.Path
        };

        if (ex is ValidationException validationException)
            problemDetails.Extensions["errors"] = validationException.Errors
                .GroupBy(error => error.PropertyName)
                .ToDictionary(failure => failure.Key, g => g
                .Select(error => error.ErrorMessage)
                .ToArray());

        problemDetails.Extensions["traceId"] = context.TraceIdentifier;

        context.Response.StatusCode = status;
        await context.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }
}
