using System.Reflection;

namespace UT1Downloader.Test
{
    internal static class File
    {
        public static Stream GetFileStream(String file)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = $"{typeof(File).Namespace}.{file}";

            var stream = assembly.GetManifestResourceStream(resourceName);

            return stream ?? throw new ArgumentException("File was not found.");
        }
    }
}
