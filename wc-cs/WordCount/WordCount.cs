using System.Text;

namespace wc_cs;

public static class WordCount
{
    public static int CalculateLines(string textContent)
    {
        return textContent.Split(Environment.NewLine).Length;
    }
    
    public static int CalculateWords(string textContent)
    {
        return textContent.Split(" ").Length;
    }
    
    public static int CalculateCharacters(string textContent)
    {
        return textContent.Length;
    }

    
    public static int CalculateBytes(string textContent)
    {
        return Encoding.UTF8.GetByteCount(textContent);
    }
    
    public static string LoadTextContentFromFile(string filePath)
    {
        return File.ReadAllText(filePath);
    }
}