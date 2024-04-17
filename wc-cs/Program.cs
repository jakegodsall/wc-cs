using wc_cs;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length > 0)
        {
            Console.WriteLine("Arguments provided");
            foreach (var arg in args)
            {
                Console.WriteLine(arg);
            }
        }
        else
        {
            Console.WriteLine("No arguments provided");
        }

        var commandLineArgumentParser = InitialiseCommandLineArgumentParser();
        
        commandLineArgumentParser.ParseArgs(args);
    }

    public static CommandLineArgumentParser InitialiseCommandLineArgumentParser()
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
