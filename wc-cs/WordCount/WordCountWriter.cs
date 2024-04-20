namespace wc_cs;

public class WordCountWriter
{
    public static void Write(string textContent, string fileName, HashSet<string> options)
    {
        var output = "";
        
        if (options.Contains("-l") || options.Contains("--lines"))
        {
            output += PadLeft(WordCount.CalculateLines(textContent), 8);
        }
        if (options.Contains("-w") || options.Contains("--words"))
        {
            output += PadLeft(WordCount.CalculateWords(textContent), 8);
        }
        if (options.Contains("-m") || options.Contains("--characters"))
        {
            output += PadLeft(WordCount.CalculateCharacters(textContent), 8);
        }
        if (options.Contains("-c") || options.Contains("--bytes"))
        {
            output += PadLeft(WordCount.CalculateBytes(textContent), 8);
        }
        
        output += " " + fileName;
        Console.WriteLine(output);
    }

    private static string PadLeft(int value, int totalLength)
    {
        return value.ToString().PadLeft(totalLength);
    }
}
