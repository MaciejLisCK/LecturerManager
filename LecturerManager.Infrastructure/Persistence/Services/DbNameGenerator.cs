using LecturerManager.Infrastructure.Services;

namespace LecturerManager.Infrastructure.Persistence.Services;

public static class DbNameGenerator
{
    public static string GenerateTableName(string clrName)
    {
        if (string.IsNullOrWhiteSpace(clrName))
            return clrName;
     
        var prefix = PrefixGenerator.Generate(clrName);
        var snakeCaseName = SnakeCaseConverter.FromPascalCase(clrName);
        
        return $"{prefix}_{snakeCaseName}";
    }

    public static string GenerateColumnName(string clrName)
    {
        if (string.IsNullOrWhiteSpace(clrName))
            return clrName;
        return SnakeCaseConverter.FromPascalCase(clrName);
    }
}
