// See https://aka.ms/new-console-template for more information
using CommandLine;
using Spectre.Console;
using System.Text;
using UT1Downloader;
using UT1Downloader.Http;
using UT1Downloader.Input;
using UT1Downloader.Output;

await Parser.Default.ParseArguments<Options>(args)
    .WithParsedAsync(async (options) =>
    {
        var console = new FancyConsole();
        var input = new TarGzWebInput(@"http://dsi.ut-capitole.fr/blacklists/download/", new Http(console), console);
        IOutputGenerator generator = options.OutputStyle == "abp" ? new AdblockPlusOutputGenerator() : new HostOutputGenerator();

        var outputDirectory = Path.GetFullPath(options.Output);

        if (!Directory.Exists(outputDirectory))
        {
            console.WriteError($"Directory {outputDirectory} does not exist. Creating...");
            try
            {
                Directory.CreateDirectory(outputDirectory);
            }
            catch (Exception e)
            {
                console.WriteException(e);
                Environment.Exit(1);
            }
            console.WriteSuccess("Directory created.");
        }
        else
        {
            console.WriteSuccess("Output directory exists");
        }

        foreach (String category in options.Categories)
        {
            console.WriteLine($"{Emoji.Known.RightArrow} Working on category {category}...");

            var contents = await input.GetInputAsync(category);

            var output = new StringBuilder();
            using (var reader = new StringReader(contents))
            {
                string? line = string.Empty;
                while ((line = reader.ReadLine()) != null)
                {
                    var generated = generator.TransformLine(line);

                    foreach (var generatedLine in generated)
                    {
                        output.AppendLine(generatedLine);
                    }
                }
            }

            var outputContent = output.ToString();

            var file = Path.Combine(outputDirectory, $"{category}.txt");
            console.WriteStatus($"Saving file to {file}...");

            using (var writer = new StreamWriter(file))
            {
                writer.Write(outputContent);
            }

            console.WriteSuccess($"Category {category} completed.");
        }
    });


