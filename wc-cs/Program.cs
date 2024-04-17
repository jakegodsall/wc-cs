using System.Runtime.CompilerServices;
using wc_cs;

class Program
{
    static void Main(string[] args)
    {
        
        var commandLineArgumentParser = InitialiseCommandLineArgumentParser();

        var options = args.Take(args.Length - 1).ToArray();
        
        commandLineArgumentParser.ParseOptions(options);
        commandLineArgumentParser.ValidateFileExists(args[args.Length - 1]);
        
        Console.WriteLine(commandLineArgumentParser.SelectedArgumentsToString());

        var wordCount = new WordCount();
        if (commandLineArgumentParser.SelectedArgumentsIncludesShort('c'))
        {
        }

    }

    private static CommandLineArgumentParser InitialiseCommandLineArgumentParser()
    {
        var commandLineArgumentParser = new CommandLineArgumentParser();
        commandLineArgumentParser.AddValidCommandLineArguments(
            new CommandLineArgument('l', "lines", false, "Display the number of lines in the terminal window"),
            new CommandLineArgument('w', "words", false, "Display the number of words in the terminal window"),
            new CommandLineArgument('m', "characters", false, "Display the number of characters in the terminal window"),
            new CommandLineArgument('c', "bytes", false, "Display the number of bytes in the terminal window")
            );
        return commandLineArgumentParser;
    }
}
