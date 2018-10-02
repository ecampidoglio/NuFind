using System.Collections.Generic;
using NuFind.Search;

namespace NuFind.Output
{
    public interface IFormat
    {
        string Render(IEnumerable<PackageMetadata> packages);
    }
}
