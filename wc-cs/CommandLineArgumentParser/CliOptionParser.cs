using System.Runtime.InteropServices.JavaScript;
using static System.String;

namespace wc_cs;


public class CliOptionParser
{
    public Dictionary<string, CliOption> ValidOptions = [];
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

            
            
            // otherwise if arg has option syntax
            if (ValidOptions.TryGetValue(arg, out var option))
            {
                ParsedOptions.Add(arg);
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
            ValidOptions.Add($"-{option.ShortName}", option);
        }

        if (!IsNullOrEmpty(option.LongName))
        {
            ValidOptions.Add($"--{option.LongName}", option);
        }
    }
}