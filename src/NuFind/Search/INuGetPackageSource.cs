using System.Collections.Generic;

namespace NuFind.Search
{
    public interface INuGetPackageSource
    {
        IReadOnlyCollection<PackageMetadata> Search(
            string keywords,
            bool includePreRelease = false);
    }
}
