using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace LecturerManager.Domain.Shared.Exceptions;

public class DomainArgumentNullException(string message) : DomainException(message)
{
    public static void ThrowIfNull([NotNull] object? value, [CallerArgumentExpression(nameof(value))] string? fieldName = null)
    {
        if (value is null)
            throw new DomainArgumentNullException($"Field '{fieldName}' should not be null.")
            {
                Data =
                {
                    ["FieldName"] = fieldName,
                }
            };
    }
}