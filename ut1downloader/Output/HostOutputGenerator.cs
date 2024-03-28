namespace UT1Downloader.Output
{
    public class HostOutputGenerator : IOutputGenerator
    {
        public string[] TransformLine(string line)
        {
            if (Uri.CheckHostName(line.Trim()) == UriHostNameType.Dns)
            {
                return [$"0.0.0.0 {line}"];
            }

            return [];
        }
    }
}
