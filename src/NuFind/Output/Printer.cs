using System.Collections.Generic;
using NuFind.Search;

namespace NuFind.Output
{
    public class Printer
    {
        private readonly IFormat _format;
        private readonly IOutput _output;

        public Printer(IFormat format, IOutput output)
        {
            _format = format;
            _output = output;
        }

        public void Print(IEnumerable<PackageMetadata> packages)
        {
            _output.Send(_format.Render(packages));
        }
    }
}
