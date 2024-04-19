namespace wc_cs;

public class CliOption
{
    public string ShortName { get; set; }
    public string LongName { get; set; }
    public bool IsRequired { get; set; }
    public string HelpText { get; set; }
    public bool IsPresent { get; set; }
    public Action<string> Action { get; set; }

    public CliOption(
        string shortName,
        string longName,
        bool isRequired,
        string helpText,
        Action<string> action
        )
    {
        ShortName = shortName;
        LongName = longName;
        IsRequired = isRequired;
        HelpText = helpText;
        Action = action;
    }

    public override string ToString()
    {
        return $"(short='-{ShortName}', long='--{LongName}', required='{IsRequired}', description='{HelpText}')";
    }
}