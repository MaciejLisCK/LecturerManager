using System.Runtime.CompilerServices;

namespace LecturerManager.Domain.Shared.Exceptions;

public class DomainStringLengthExceededException(string message) : DomainException(message)
{
    public static void ThrowIfLengthExceeded(string value, int maxLength, [CallerArgumentExpression(nameof(value))] string? fieldName = null)
    {
        var length = value.Length;
        if (length > maxLength)
            throw new DomainStringLengthExceededException($"Field '{fieldName}' value length too long. Length: {length}. Max length: {maxLength}.")
            {
                Data =
                {
                    ["FieldName"] = fieldName,
                    ["StringLength"] = length,
                    ["MaxLength"] = maxLength,
                }
            };
    }
}