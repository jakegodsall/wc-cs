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
        
        for (var i = 0; i < args.Length - 1; i++)
        {
            var arg = args[i];
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
                if (argVal.Length == 1)
                {
                    foundArg = _validArgs.FirstOrDefault(a => char.Parse(argVal) == a.ShortArg);
                }
                else
                {
                    throw new ArgumentException($"Unknown or incorrect argument {arg}.");
                }
            }
            else if (argType == "long")
            {
                foundArg = _validArgs.FirstOrDefault(a => argVal == a.LongArg);
            }

            if (foundArg != null)
            {
                foundArg.IsPresent = true;
            }
            else
            {
                throw new ArgumentException($"Unknown or incorrect argument {arg}.");
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
        throw new NotImplementedException();
    }

    public string SelectedArgumentsToString()
    {
        var strRepr = "(\n";
        foreach (var arg in _validArgs)
            if (arg.IsPresent)
            {
                strRepr += "    " +  arg + "\n";
            }
        strRepr += ")";
        return strRepr;
    }
    
    public string ValidArgumentsToString()
    {
        var strRepr = "(\n";
        foreach (var arg in _validArgs)
        {
            strRepr += "    " +  arg + "\n";
        }

        strRepr += ")";
        return strRepr;
    }
}