namespace UT1Downloader.Output
{
    public class AdblockPlusOutputGenerator : IOutputGenerator
    {
        public string[] TransformLine(string line)
        {
            line = line.Trim();

            if (Uri.CheckHostName(line) == UriHostNameType.Dns)
            {
                return [$"||{line}^"];
            }

            return [];
        }
    }
}
