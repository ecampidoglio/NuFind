using System.Collections.Generic;
using NuFind.CommandLine;
using NuFind.Search;

namespace NuFind.Output
{
    public static class OutputExtensions
    {
        public static void PrintResults(
            this (IReadOnlyCollection<PackageMetadata> Packages, Arguments Arguments) context)
        {
            Printer.Create(context.Arguments.Format)
                   .Print(context.Packages);
        }
    }
}
