namespace PrepareServiceParams.GitHubAction.Extensions;

public static class StringExtension
{
    public static string Clear(this string line)
    {
        return string.IsNullOrWhiteSpace(line)
            ? null
            : line.ToLower().Trim();
    }
    
    public static string KebabCaseSecondWord(this string line)
    {
        var words = line.Split("-");

        return words.Length < 2
            ? null
            : words[1].Clear();
    }
}