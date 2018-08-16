using System.Collections.Generic;
using NuFind.Search;

namespace NuFind.Output
{
    public class Printer
    {
        private static readonly AvailableFormats Formats = new AvailableFormats();

        private readonly IFormat _format;
        private readonly IOutput _output;

        protected Printer(IFormat format, IOutput output)
        {
            _format = format;
            _output = output;
        }

        public static Printer Create(string formatName)
        {
            return new ConsolePrinter(Formats.ByName(formatName));
        }

        public void Print(IEnumerable<PackageMetadata> packages)
        {
            _output.Send(_format.Render(packages));
        }
    }
}
