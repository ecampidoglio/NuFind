using System.Collections.Generic;
using NuFind.CommandLine;

namespace NuFind.Search
{
    public static class SearchExtensions
    {
        public static IReadOnlyCollection<PackageMetadata> SearchPackages(
            this Arguments arguments)
        {
            return new NuGetPackageFeedV2().Search(
                arguments.SearchTerm,
                arguments.IncludePreRelease);
        }
    }
}
