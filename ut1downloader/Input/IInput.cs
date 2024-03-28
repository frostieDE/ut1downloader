namespace UT1Downloader.Input
{
    public interface IInput
    {
        public Task<string> GetInputAsync(string category);
    }
}
