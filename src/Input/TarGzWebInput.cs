using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.Tar;
using System.Text;
using UT1Downloader.Http;

namespace UT1Downloader.Input
{
    public class TarGzWebInput(string baseUrl, IHttp httpClient, IConsole console) : IInput
    {
        private readonly IConsole console = console;

        public async Task<string> GetInputAsync(string category)
        {
            var response = await httpClient.DownloadAsStream($"{baseUrl}/{category}.tar.gz");            

            if(response == null)
            {
                console.WriteError($"Downloading failed.");
                return "";
            }

            var entryFound = false;
            string input = string.Empty;
            console.WriteStatus($"Extracting domains file into memory");

            using (var gzipStream = new GZipInputStream(response))
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
                console.WriteError($"File domains not present in archive.");
            }

            return input;
        }
    }
}
