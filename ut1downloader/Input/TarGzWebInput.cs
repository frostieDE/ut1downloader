using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.Tar;
using System.Text;

namespace UT1Downloader.Input
{
    public class TarGzWebInput(string baseUrl, IConsole console) : IInput
    {
        private readonly string baseUrl = baseUrl;
        private readonly IConsole console = console;

        public async Task<string> GetInputAsync(string category)
        {
            using var client = new HttpClient();
            var downloadUrl = $"{this.baseUrl}/{category}.tar.gz";
            console.WriteStatus($"Downloading {category}...");
            var response = await client.GetAsync(downloadUrl);
            console.WriteSuccess("Download completed.");

            response.EnsureSuccessStatusCode();

            var entryFound = false;
            string input = string.Empty;
            console.WriteStatus($"Extracting domains file into memory");

            using (var gzipStream = new GZipInputStream(response.Content.ReadAsStream()))
            {
                using var tarStream = new TarInputStream(gzipStream, Encoding.UTF8);
                TarEntry entry;
                while ((entry = tarStream.GetNextEntry()) != null)
                {
                    if (entry.Name.EndsWith("/domains"))
                    {
                        var outputStream = new MemoryStream();
                        tarStream.CopyEntryContents(outputStream);
                        outputStream.Position = 0;

                        input = Encoding.UTF8.GetString(outputStream.ToArray());
                        entryFound = true;
                    }
                }
            }

            if (entryFound == false)
            {
                console.WriteError($"File domains not present in archive. Downloaded from: {downloadUrl}");
            }

            return input;
        }
    }
}
