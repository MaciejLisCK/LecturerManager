using System.Runtime.CompilerServices;

namespace LecturerManager.Domain.Shared.Exceptions;

public class DomainStringEmptyException(string message) : DomainException(message)
{
    public static void ThrowIfEmpty(string value, [CallerArgumentExpression(nameof(value))] string? fieldName = null)
    {
        if (String.IsNullOrWhiteSpace(value))
            throw new DomainStringEmptyException($"Field '{fieldName}' should not be empty.")
            {
                Data =
                {
                    ["FieldName"] = fieldName,
                }
            };
    }
}