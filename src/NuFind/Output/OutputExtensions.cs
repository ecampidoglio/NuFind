using System.Collections.Generic;
using NuFind.Search;

namespace NuFind.Output
{
    public static class OutputExtensions
    {
        public static void PrintResults(
            this IReadOnlyCollection<PackageMetadata> packages)
        {
            new ConsolePrinter().Print(packages);
        }
    }
}
