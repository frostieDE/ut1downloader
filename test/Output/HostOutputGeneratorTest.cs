using UT1Downloader.Output;

namespace UT1Downloader.Test.Output
{
    [TestClass]
    public class HostOutputGeneratorTest
    {
        private static readonly string[] expected = new string[] { "0.0.0.0 example.com" };

        [TestMethod]
        public void TestTransformValidLine()
        {
            string validLine = "example.com";
            var generator = new HostOutputGenerator();

            CollectionAssert.AreEqual(expected, generator.TransformLine(validLine));
        }

        [TestMethod]
        public void TestIgnoreIpAdresses()
        {
            string ipAddress = "8.8.8.8";
            var generator = new HostOutputGenerator();

            CollectionAssert.AreEqual(Array.Empty<string>(), generator.TransformLine(ipAddress));
        }

        [TestMethod]
        public void TestIgnoreWhitespaces()
        {
            string addressWithWhitespace = "example.com ";
            var generator = new HostOutputGenerator();

            CollectionAssert.AreEqual(expected, generator.TransformLine(addressWithWhitespace));
        }

        [TestMethod]
        public void TestAddressesWithNonAsciiCharacters()
        {
            string address = "nicht-ungültig.org";
            var generator = new HostOutputGenerator();

            CollectionAssert.AreEqual(new string[] { "0.0.0.0 nicht-ungültig.org" }, generator.TransformLine(address));
        }
    }
}
