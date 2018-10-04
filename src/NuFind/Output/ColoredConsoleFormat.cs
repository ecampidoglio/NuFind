using System;
using System.Collections.Generic;
using System.Linq;
using NuFind.Search;

namespace NuFind.Output
{
    public class ColoredConsoleFormat : INamedFormat
    {
        public string Name => "Console";

        public string Render(IEnumerable<PackageMetadata> packages)
        {
            var lines = packages.Select(FormatLine);
            return string.Concat(lines);
        }

        private static string FormatLine(PackageMetadata p) =>
            $"{p.Id} " +
            $"=> {(p.IsPreRelease ? AnsiColors.Red : AnsiColors.Green)}{p.Version}{AnsiColors.Reset} " +
            $"{AnsiColors.Cyan}({p.Authors}){AnsiColors.Reset}" +
            Environment.NewLine;

        private static class AnsiColors
        {
            public const string Red = "\u001b[31m";
            public const string Green = "\u001b[32m";
            public const string Cyan = "\u001b[36m";
            public const string Reset = "\u001b[0m";
        }
    }
}
