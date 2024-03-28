namespace UT1Downloader.Http
{
    public interface IHttp
    {
        public Task<Stream> DownloadAsStream(string url);
    }
}
