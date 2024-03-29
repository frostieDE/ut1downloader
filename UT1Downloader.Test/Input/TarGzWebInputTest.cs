using Moq;
using System.Text;
using UT1Downloader.Http;
using UT1Downloader.Input;

namespace UT1Downloader.Test.Input
{
    [TestClass]
    public class TarGzWebInputTest
    {
        [TestMethod]
        public async Task TestInvalidArchive()
        {
            var console = new Mock<IConsole>();
            var http = new Mock<IHttp>();
            http.Setup(http => http.DownloadAsStream(It.IsAny<string>()))
                .ReturnsAsync(File.GetFileStream("TestData.invalid.tar.gz"));

            var input = new TarGzWebInput("https://example.com", http.Object, console.Object);
            var result = await input.GetInputAsync("test");

            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public async Task TestValidArchive()
        {
            var console = new Mock<IConsole>();
            var http = new Mock<IHttp>();
            http.Setup(http => http.DownloadAsStream(It.IsAny<string>()))
                .ReturnsAsync(File.GetFileStream("TestData.valid.tar.gz"));

            var input = new TarGzWebInput("https://example.com", http.Object, console.Object);
            var result = await input.GetInputAsync("test");

            // The provided test file has \r\n line endings so we need to ensure them in our expected string :)
            var expected = string.Join("\r\n", new string[] { "example.com", "example.org", "example.net" });

            Assert.AreEqual(expected, result);
        }
    }
}
