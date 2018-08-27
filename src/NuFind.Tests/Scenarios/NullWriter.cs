using System.IO;
using System.Text;

namespace NuFind.Tests.Scenarios
{
    internal class NullWriter : TextWriter
    {
        public override Encoding Encoding => Encoding.Default;
    }
}
