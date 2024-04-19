namespace wc_cs;

public class WordCountWriter
{
    public static void WriteLines(string textContent, string fileName)
    {
        var lines = WordCount.CalculateLines(textContent);
        Console.WriteLine(lines + " " + fileName);
    }

    public static void WriteWords(string textContent, string fileName)
    {
        var words = WordCount.CalculateWords(textContent);
        Console.WriteLine(words + " " + fileName);
    }

    public static void WriteCharacters(string textContent, string fileName)
    {
        var characters = WordCount.CalculateCharacters(textContent);
        Console.WriteLine(characters + " " + fileName);
    }

    public static void WriteBytes(string textContent, string fileName)
    {
        var bytes = WordCount.CalculateBytes(textContent);
        Console.WriteLine(bytes + " " + fileName);
    }
}
