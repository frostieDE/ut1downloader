namespace UT1Downloader.Output
{
    public class AdblockPlusOutputGenerator : IOutputGenerator
    {
        public string[] TransformLine(string line)
        {
            if (Uri.CheckHostName(line.Trim()) == UriHostNameType.Dns)
            {
                return [$"||{line}^"];
            }

            return [];
        }
    }
}
