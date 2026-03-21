using System.Runtime.CompilerServices;

namespace LecturerManager.Domain.Shared.Exceptions;

public class DomainUrlFormatException(string message) : DomainException(message)
{
    public static void ThrowIfLengthExceeded(string value, [CallerArgumentExpression(nameof(value))] string? fieldName = null)
    {
        var isValidUrl =
            Uri.TryCreate(value, UriKind.Absolute, out var uri) &&
            (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps);
        if (isValidUrl)
            throw new DomainUrlFormatException($"Field '{fieldName} wrong URL format.")
            {
                Data =
                {
                    ["FieldName"] = fieldName,
                    ["FieldValue"] = value,
                }
            };
    }
}