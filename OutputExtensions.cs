using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace NuFind
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
                Console.WriteLine(package.Version);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        internal static void PrintAlfredResults(this IEnumerable<PackageMetadata> packages)
        {
            var items = new
            {
                items = packages.Select(p => new
                {
                    title = p.Id,
                    subtitle = p.Version,
                    arg = $"\"{p.Id}\": \"{p.Version}\"",
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
