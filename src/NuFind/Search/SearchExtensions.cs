using System.Collections.Generic;
using NuFind.CommandLine;

namespace NuFind.Search
{
    public static class SearchExtensions
    {
        public static (IReadOnlyCollection<PackageMetadata>, Arguments) SearchPackages(
            this Arguments arguments)
        {
            var packages = new NuGetPackageFeedV2().Search(
                arguments.SearchTerm,
                arguments.IncludePreRelease);

            return (packages, arguments);
        }
    }
}
