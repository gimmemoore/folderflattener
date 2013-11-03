using CommandLine;
using CommandLine.Text;

namespace FolderFlattener
{
    public class Options 
    {
        [OptionArray('r', "root", Required = true, HelpText = "The list of root directories from which flattening will start.")]
        public string[] Root { get; set; }

        [Option('v', "verbose", DefaultValue = true, HelpText = "Prints all messages to standard output.")]
        public bool Verbose { get; set; }

        [Option('d', "destination", Required = false, DefaultValue = "Flattened", HelpText = "The destination folder where files will be sent.")]
        public string Destination { get;set; }

        [HelpOption]
        public string GetUsage()
        {
            var help = new HelpText
            {
                Heading = new HeadingInfo("Flatten Directory", "0.1"),
                Copyright = new CopyrightInfo("Kevin Moore (http://about.me/kevinmooreqc)", 2013),
                AdditionalNewLineAfterOption = true,
                AddDashesToOption = true
            };

            help.AddOptions(this);
            return help;
        }
    }
}