using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using NuFind.Search;

namespace NuFind.CommandLine
{
    internal static class OutputExtensions
    {
        internal static void PrintResults(this IEnumerable<PackageMetadata> packages)
        {
            foreach (var package in packages)
            {
                Console.Write(package.Id);
                Console.Write(" → ");
                Console.ForegroundColor = package.IsPreRelease ? ConsoleColor.Red : ConsoleColor.Green;
                Console.Write(package.Version);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write($" ({package.Authors})");
                Console.WriteLine();
                Console.ResetColor();
            }
        }

        internal static void PrintAlfredResults(this IEnumerable<PackageMetadata> packages)
        {
            var items = new
            {
                items = packages.Select(p => new
                {
                    title = p.Id,
                    subtitle = $"{p.Version} • {p.Authors}",
                    arg = $"<PackageReference Include=\"{p.Id}\" Version=\"{p.Version}\" />",
                    autocomplete = p.Id,
                    icon = new {
                        path = "icon.png"
                    }
                })
            };
            Console.WriteLine(JsonConvert.SerializeObject(items));
        }
    }
}
