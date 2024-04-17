using System.Text;

namespace wc_cs;

public class WordCount
{
    private string TextContent { get; set; }

    public WordCount(string filePath)
    {
        TextContent = LoadTextContentFromFile(filePath);
    }
    
    private int CalculateBytes()
    {
        return Encoding.UTF8.GetByteCount(TextContent);
    }
    
    private int CalculateCharacters()
    {
        return TextContent.Length;
    }
    
    private int CalculateWords()
    {
        return TextContent.Split(" ").Length;
    }
    
    private int CalculateLines()
    {
        return TextContent.Split(Environment.NewLine).Length;
    }
    
    private string LoadTextContentFromFile(string filePath)
    {
        return File.ReadAllText(filePath);
    }
}