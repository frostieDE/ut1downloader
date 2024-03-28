using CommandLine;

namespace UT1Downloader
{
    public class Options
    {
        [Option('c', Required = true, Separator = ',', HelpText = "Specifies the categories which are downloaded and transformed.")]
        public IEnumerable<string> Categories { get; set; } = new List<string>();

        [Option('s', Required = false, Default = "host", HelpText = "Specify the output style. Use 'host' for host file syntax, use 'abp' for AdBlockPlus syntax.")]
        public string OutputStyle { get; set; } = "host";

        [Option('o', Required = true, HelpText = "Directory to output files")]
        public required string Output { get; set; }
    }
}
