using System.Runtime.CompilerServices;
using wc_cs;

class Program
{
    static void Main(string[] args)
    {
        // Initialise a CliOptionParser with the available options
        var parser = InitialiseCommandLineArgumentParser();
        // Get the options from the command line
        
        
        parser.ParseOptions(args);
       

    }

    private static CliOptionParser InitialiseCommandLineArgumentParser()
    {
        // Instantiate a CLIOptionParser
        var parser = new CliOptionParser();
        // Register the legitimate options with the parser
        parser.RegisterOption(new CliOption("l", "lines", false, "Display the number of lines in the terminal window"));
        parser.RegisterOption(new CliOption("w", "words", false, "Display the number of words in the terminal window"));
        parser.RegisterOption(new CliOption("m", "characters", false, "Display the number of characters in the terminal window"));
        parser.RegisterOption(new CliOption("c", "bytes", false, "Display the number of bytes in the terminal window"));
        return parser;
    }
}
