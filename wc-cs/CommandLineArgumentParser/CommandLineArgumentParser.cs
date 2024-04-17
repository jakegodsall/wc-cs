namespace wc_cs;

public class CommandLineArgumentParser
{
    private List<CommandLineArgument> _validArgs;
    

    public CommandLineArgumentParser()
    {
        _validArgs = new List<CommandLineArgument>();
    }

    public void Parse(string[] args)
    {
        if (args.Length == 0)
        {
            throw new ArgumentException("No arguments provided.");
        }
        
        foreach (var arg in args)
        {
            var argType = "";
            var argVal = "";
            if (arg.StartsWith("--"))
            {
                argType = "long";
                argVal = arg.Substring(2);
            }
            else if (arg.StartsWith('-'))
            {
                argType = "short";
                argVal = arg.Substring(1);
            }

            CommandLineArgument foundArg = null;
            if (argType == "short")
            {
                foundArg = _validArgs.FirstOrDefault(a => char.Parse(argVal) == a.ShortArg));
            }
            else if (argType == "long")
            {
                foundArg = _validArgs.FirstOrDefault(a => argVal == a.LongArg);
            }

            if (foundArg != null)
            {
                foundArg.IsPresent = true;
            }
        }
    }

    public void AddValidCommandLineArgument(CommandLineArgument commandLineArgument)
    {
        _validArgs.Add(commandLineArgument);
    }

    public void AddValidCommandLineArguments(params CommandLineArgument[] commandLineArguments)
    {
        foreach (var commandLineArgument in commandLineArguments)
        {
            _validArgs.Add(commandLineArgument);
        }
    }

    public bool RequiredArgumentIsPresent()
    {
        
    }
}