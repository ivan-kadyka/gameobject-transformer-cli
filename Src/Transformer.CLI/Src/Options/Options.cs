using CommandLine;

namespace Transformer.CLI.Options;

/// <summary>
/// Represents the command-line options for the application.
/// </summary>
public class Options : IOptions
{
    /// <summary>
    /// Gets or sets the input file path.
    /// </summary>
    [Option('i', "input", Required = true, HelpText = "The path to the input file.")]
    public string Input { get; set; }

    /// <summary>
    /// Gets or sets the output file path.
    /// </summary>
    [Option('o', "output", Required = true, HelpText = "The path to the output file.")]
    public string Output { get; set; }
}