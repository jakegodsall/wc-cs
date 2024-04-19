using System.Runtime.InteropServices.JavaScript;
using static System.String;

namespace wc_cs;


public class CliOptionParser
{
    private Dictionary<string, CliOption> _validOptions = [];
    private HashSet<string> _parsedOptions = [];

    public void ParseOptions(IEnumerable<string> args)
    {
        foreach (var arg in args)
        {
            if (_validOptions.TryGetValue(arg, out var option))
            {
                _parsedOptions.Add(arg);
            }
            else
            {
                Console.WriteLine($"Unknown or invalid option: {arg}");
            }
        }
    }

    public void RegisterOption(CliOption option)
    {
        if (!IsNullOrEmpty(option.ShortName))
        {
            _validOptions.Add($"-{option.ShortName}", option);
        }

        if (!IsNullOrEmpty(option.LongName))
        {
            _validOptions.Add($"--{option.LongName}", option);
        }
    }
}