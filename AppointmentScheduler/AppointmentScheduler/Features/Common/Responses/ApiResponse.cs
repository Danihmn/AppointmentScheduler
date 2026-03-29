namespace AppointmentScheduler.Features.Common.Responses;

public sealed class ApiResponse<T>
{
    public bool Success { get; init; }
    public T? Data { get; init; }
    public string Message { get; init; } = string.Empty;

    public static ApiResponse<T> Ok (T data, string message = "Operação realizada com sucesso.") =>
        new() { Success = true, Data = data, Message = message };

    public static ApiResponse<T> Created (T data, string message = "Recurso criado com sucesso.") =>
        new() { Success = true, Data = data, Message = message };
}
