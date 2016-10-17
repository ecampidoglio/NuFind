using System;
using System.Collections.Generic;

namespace NuFind
{
    internal static class OutputExtensions
    {
        internal static void PrintResults(this IEnumerable<PackageMetadata> packages)
        {
            foreach (var package in packages)
            {
                Console.Write(package.Id);
                Console.ForegroundColor = package.IsPreRelease ? ConsoleColor.Red : ConsoleColor.Green;
                Console.Write(' ');
                Console.WriteLine(package.Version);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
