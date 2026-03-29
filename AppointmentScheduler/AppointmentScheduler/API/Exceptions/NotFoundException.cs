namespace AppointmentScheduler.API.Exceptions;

public sealed class NotFoundException (string resource, object? id)
    : Exception(id is not null ? $"{resource} com id '{id}' não foi encontrado." :
        $"{resource} não foi encontrado.");
