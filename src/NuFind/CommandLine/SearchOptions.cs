using System;
using System.Collections.Generic;
using CommandLine;

namespace NuFind.CommandLine
{
    public class SearchOptions
    {
        [Value(0,
            Required = true,
            MetaName = "search term(s)",
            HelpText = "One or more terms to search for in the NuGet Gallery.")]
        public string SearchTerm { get; set; }

        [Option('p', "prerelease",
            HelpText = "Indicates whether to include pre-release versions of the package.")]
        public bool IncludePreRelease { get; set; }

        public static SearchOptions Parse(IEnumerable<string> args)
        {
            var result = Parser.Default.ParseArguments<SearchOptions>(args);

            switch (result)
            {
                case Parsed<SearchOptions> options:
                    return options.Value;
                case NotParsed<SearchOptions> options:
                    throw new ArgumentException(string.Join("\\n", options.Errors));
                default: return default;
            }
        }
    }
}
