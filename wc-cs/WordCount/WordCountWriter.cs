namespace wc_cs;

public class WordCountWriter
{
    public static void Write(string textContent, string fileName, HashSet<string> options)
    {
        var output = "";
        
        if (options.Contains("-l") || options.Contains("--lines"))
        {
            output += WordCount.CalculateLines(textContent) + " ";
        }
        if (options.Contains("-w") || options.Contains("--words"))
        {
            output += WordCount.CalculateWords(textContent) + " ";
        }
        if (options.Contains("-m") || options.Contains("--characters"))
        {
            output += WordCount.CalculateCharacters(textContent) + " ";
        }
        if (options.Contains("-c") || options.Contains("--bytes"))
        {
            output += WordCount.CalculateBytes(textContent) + " ";
        }
        
        output += " " + fileName;
        Console.WriteLine(output);
    }
}
