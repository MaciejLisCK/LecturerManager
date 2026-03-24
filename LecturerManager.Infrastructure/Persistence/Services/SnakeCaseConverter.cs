using System;
using System.Collections.Generic;
using System.Text;

namespace LecturerManager.Infrastructure.Services;

public static class SnakeCaseConverter
{
    public static string FromPascalCase(string pascalCaseInput)
    {
        if (string.IsNullOrWhiteSpace(pascalCaseInput))
            return pascalCaseInput;
        var words = System.Text.RegularExpressions.Regex.Split(pascalCaseInput, @"(?<!^)(?=[A-Z])")
                          .Where(s => !string.IsNullOrEmpty(s))
                          .ToArray();
        return string.Join("_", words.Select(w => w.ToLowerInvariant()));
    }
}
