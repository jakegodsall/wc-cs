namespace wc_cs;

public class CliOptionParser
{
    private Dictionary<string, CliOption> _validOptions = [];
    private HashSet<string> _parsedOptions = [];


    public void ParseOptions(IEnumerable<string> args)
    {
        // Check if provided args are legitimate
        foreach (var arg in args)
        {
            if (_validOptions.TryGetValue(arg, out CliOption option))
            {
                option.Action?.Invoke();
                _parsedOptions.Add(arg);
            }
            else
            {
                Console.WriteLine($"Unknown or invalid option: {arg}");
            }
        }
        
        // Check for missing required options
        foreach (var opt in _validOptions.Values)
        {
            if (opt.IsRequired && !_parsedOptions.Contains("-" + opt.ShortName) &&
                !_parsedOptions.Contains("--" + opt.LongName))
            {
                Console.WriteLine($"Missing required option: {opt.ShortName} or {opt.LongName}");
            }
        }
    }
    
    public void RegisterOption(CliOption option)
    {
        if (!string.IsNullOrEmpty(option.ShortName))
        {
            _validOptions["-" + option.ShortName] = option;
        }

        if (!string.IsNullOrEmpty(option.LongName))
        {
            _validOptions["--" + option.LongName] = option;
        }
    }
    
}