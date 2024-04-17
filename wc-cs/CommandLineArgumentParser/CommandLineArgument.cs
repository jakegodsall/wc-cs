namespace wc_cs;

public class CommandLineArgument
{
    public char ShortArg { get; set; }
    public string LongArg { get; set; }
    public bool IsRequired { get; set; }
    public string HelpText { get; set; }
    public bool IsPresent { get; set; }
    public string Value { get; set; }

    public CommandLineArgument(char shortArg, string longArg, bool isRequired, string helpText)
    {
        ShortArg = shortArg;
        LongArg = longArg;
        IsRequired = isRequired;
        HelpText = helpText;
    }

    public override string ToString()
    {
        return $"(short='-{ShortArg}', long='--{LongArg}', required='{IsRequired}', description='{HelpText}')";
    }
}