namespace UT1Downloader.Output
{
    public class HostOutputGenerator : IOutputGenerator
    {
        public string[] TransformLine(string line)
        {
            line = line.Trim();

            if (Uri.CheckHostName(line) == UriHostNameType.Dns)
            {
                return [$"0.0.0.0 {line}"];
            }

            return [];
        }
    }
}
