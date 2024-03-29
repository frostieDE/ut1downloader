using Spectre.Console;

namespace UT1Downloader
{
    public class FancyConsole : IConsole
    {
        public void WriteError(string message)
        {
            AnsiConsole.MarkupLine($"[red]{Emoji.Known.RedExclamationMark}[/] {message}");
        }

        public void WriteException(Exception e)
        {
            AnsiConsole.WriteException(e);
        }

        public void WriteLine(string message)
        {
            AnsiConsole.MarkupLine(message);
        }

        public void WriteStatus(string message)
        {
            AnsiConsole.MarkupLine($":play_button: {message}");
        }

        public void WriteSuccess(string message)
        {
            AnsiConsole.MarkupLine($"[green]{Emoji.Known.CheckMark}[/] {message}");
        }
    }
}
