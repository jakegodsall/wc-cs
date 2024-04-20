using System.Runtime.InteropServices.JavaScript;
using static System.String;

namespace wc_cs;


public class CliOptionParser
{
    private readonly Dictionary<string, CliOption> _validOptions = [];
    public HashSet<string> ParsedOptions = [];
    public string FilePath { get; set; }

    public void ParseOptions(IEnumerable<string> args)
    {
        string potentialFilePath = null;
        
        foreach (var arg in args)
        {
            // determine if arg is a legitimate filepath
            if (!arg.StartsWith("-"))
            {
                potentialFilePath = arg;
                
                if (File.Exists(potentialFilePath))
                {
                    FilePath = potentialFilePath;
                    continue;
                }
                Console.WriteLine($"File does not exist at: {potentialFilePath}");
            }

            List<string> currentOptionList = null;
            // otherwise if arg has option syntax
            if (arg.StartsWith("-") && arg.Length != 2)
            {
                currentOptionList = SplitShortOptions(arg);
            }
            else
            {
                currentOptionList = new List<string>();
                currentOptionList.Add(arg);
            }

            foreach (var currentOption in currentOptionList)
            {
                if (_validOptions.TryGetValue(currentOption, out var option))
                {
                    ParsedOptions.Add(currentOption);
                }
                else
                {
                    Console.WriteLine($"Unknown or invalid option: {arg}");
                }
            }
        }
    }

    public List<string> SplitShortOptions(string option)
    {
        var splitOption = option.Select(c => c.ToString()).ToList();
        splitOption.RemoveAt(0);
        return splitOption;
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