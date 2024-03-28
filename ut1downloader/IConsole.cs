namespace UT1Downloader
{
    public interface IConsole
    {
        public void WriteException(Exception e);

        public void WriteLine(string message);

        public void WriteStatus(string message);

        public void WriteSuccess(string message);

        public void WriteError(string message);
    }
}
