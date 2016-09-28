using ScreenDoctor.InputParsing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace ScreenDoctor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ICliArgumentParser parser = new CliArgumentParser();

            Console.WriteLine(parser.Help);
            var arguments = parser.Parse(args);

            var sourceFileBase = arguments.Filename;

            if (sourceFileBase == null)
            {
                Console.WriteLine("Source file name is missing. please specify it.");
            }
            else
            {
                if (sourceFileBase.EndsWith(".png"))
                {
                    sourceFileBase = sourceFileBase.Substring(0, sourceFileBase.Length - 3);
                }

                var targetFilePath = string.Concat(
                    sourceFileBase,
                    Enum.GetName(typeof(OutputFormat), arguments.OutputFormat).ToLower());

                var augmentationInfoPath = string.Concat(
                    (string)sourceFileBase,
                    "augment.txt");

                var sourceScreenshotPath = string.Concat(
                    (string)sourceFileBase,
                    "png");

                // ensure source screenshot exists:
                if (!File.Exists(sourceScreenshotPath))
                {
                    var combinedPath = Path.Combine(Directory.GetCurrentDirectory(), sourceScreenshotPath);
                    if (File.Exists(combinedPath))
                    {
                        sourceScreenshotPath = combinedPath;
                    }
                    else
                    {
                        throw new ArgumentException("Could not find the screenshot to augment.", "filename");
                    }
                }

                // ensure meta information file exists:
                if (!File.Exists(augmentationInfoPath))
                {
                    var combinedAugmentationInfoPath = Path.Combine(Directory.GetCurrentDirectory(), augmentationInfoPath);
                    if (File.Exists(combinedAugmentationInfoPath))
                    {
                        augmentationInfoPath = combinedAugmentationInfoPath;
                    }
                    else
                    {
                        throw new ArgumentException("Could not find the augmentation info for file", "filename");
                    }
                }

                using (StreamReader sr = new StreamReader(augmentationInfoPath))
                {
                    string currentLine;
                    // currentLine will be null when the StreamReader reaches the end of file
                    while ((currentLine = sr.ReadLine()) != null)
                    {
                        // Search, case insensitive, if the currentLine contains the searched keyword
                        var parts = currentLine.Split('\t');
                        
                    }
                }
            }

            Console.ReadKey();
        }
    }
}