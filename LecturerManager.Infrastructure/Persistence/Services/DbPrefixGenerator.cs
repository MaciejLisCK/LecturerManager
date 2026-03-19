using System.Text.RegularExpressions;

namespace LecturerManager.Infrastructure.Persistence.Services;

public static class PrefixGenerator
{
    private const int PrefixLength = 5;

    /// <summary>
    /// Generuje 5-znakowy prefix na podstawie nazwy w PascalCase.
    /// Np. "AccountingDocumentExportEmailState" → "adees"
    /// </summary>
    public static string Generate(string pascalCaseName)
    {
        if (string.IsNullOrWhiteSpace(pascalCaseName))
            throw new ArgumentException("Nazwa nie może być pusta.", nameof(pascalCaseName));

        var words = SplitPascalCase(pascalCaseName);

        if (words.Count == 0)
            throw new ArgumentException("Nie udało się wyodrębnić słów z nazwy.", nameof(pascalCaseName));

        string prefix = words.Count switch
        {
            1 => GenerateForOneWord(words),
            2 => GenerateForTwoWords(words),
            3 => GenerateForThreeWords(words),
            4 => GenerateForFourWords(words),
            _ => GenerateForFiveOrMoreWords(words) // 5+
        };

        return prefix.ToLowerInvariant();
    }

    /// <summary>
    /// Rozbija PascalCase na listę słów.
    /// "AccountingDocumentExportEmailState" → ["Accounting", "Document", "Export", "Email", "State"]
    /// </summary>
    private static List<string> SplitPascalCase(string input)
    {
        // Wstawia separator przed każdą wielką literą (ale nie na początku)
        var words = Regex.Split(input, @"(?<!^)(?=[A-Z])")
        .Where(w => !string.IsNullOrEmpty(w))
        .Select(w => w.ToLowerInvariant())
        .ToList();

        return words;
    }

    /// <summary>
    /// 1 słowo → pierwsze 4 znaki + "x"
    /// Np. "Address" → "addrx", "Client" → "cliex", "Brand" → "branx"
    /// </summary>
    private static string GenerateForOneWord(List<string> words)
    {
        string word = words[0];

        if (word.Length >= PrefixLength - 1)
            return word.Substring(0, PrefixLength - 1) + "x";

        return word.PadRight(PrefixLength, 'x').Substring(0, PrefixLength);
    }

    /// <summary>
    /// 2 słowa → podział proporcjonalny, faworyzujący dłuższe słowo.
    /// Stosuje podział który najlepiej pasuje do wzorców:
    /// (4,1), (3,2), (2,3)
    /// </summary>
    private static string GenerateForTwoWords(List<string> words)
    {
        // Wybierz podział proporcjonalny do długości słów
        double ratio = (double)words[0].Length / (words[0].Length + words[1].Length);

        int firstTake;
        if (ratio >= 0.65)
            firstTake = 4;
        else if (ratio >= 0.45)
            firstTake = 3;
        else
            firstTake = 2;

        int secondTake = PrefixLength - firstTake;

        return TakeLetters(words[0], firstTake) + TakeLetters(words[1], secondTake);
    }

    /// <summary>
    /// 3 słowa → podział 3+1+1 lub 2+1+2 w zależności od długości słów.
    /// </summary>
    private static string GenerateForThreeWords(List<string> words)
    {
        // Jeśli 1. słowo jest wyraźnie dłuższe, dajemy mu 3: 3+1+1
        // W przeciwnym razie: 2+1+2
        if (words[0].Length > words[2].Length)
        {
            return TakeLetters(words[0], 3)
            + TakeLetters(words[1], 1)
            + TakeLetters(words[2], 1);
        }
        else
        {
            return TakeLetters(words[0], 2)
            + TakeLetters(words[1], 1)
            + TakeLetters(words[2], 2);
        }
    }

    /// <summary>
    /// 4 słowa → podział 2+1+1+1
    /// </summary>
    private static string GenerateForFourWords(List<string> words)
    {
        return TakeLetters(words[0], 2)
        + TakeLetters(words[1], 1)
        + TakeLetters(words[2], 1)
        + TakeLetters(words[3], 1);
    }

    /// <summary>
    /// 5+ słów → po 1 literze z każdego z pierwszych 5 słów
    /// </summary>
    private static string GenerateForFiveOrMoreWords(List<string> words)
    {
        return string.Concat(words.Take(PrefixLength).Select(w => w[0]));
    }

    /// <summary>
    /// Bierze N liter z początku słowa. Jeśli słowo jest za krótkie, uzupełnia "x".
    /// </summary>
    private static string TakeLetters(string word, int count)
    {
        if (word.Length >= count)
            return word.Substring(0, count);

        return word.PadRight(count, 'x');
    }
}
