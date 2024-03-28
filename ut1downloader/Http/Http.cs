namespace UT1Downloader.Http
{
    public class Http(IConsole console) : IHttp
    {
        public async Task<Stream> DownloadAsStream(string url)
        {
            using var client = new HttpClient();
            var downloadUrl = $"{url}";
            console.WriteStatus($"Downloading {url}...");
            var response = await client.GetAsync(downloadUrl).ConfigureAwait(false);
            console.WriteSuccess("Download completed.");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        }
    }
}
