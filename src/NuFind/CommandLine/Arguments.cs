using System;
using System.Collections.Generic;
using CommandLine;

namespace NuFind.CommandLine
{
    public class Arguments
    {
        public Arguments(
            string searchTerm,
            bool includePreRelease,
            string format)
        {
            SearchTerm = searchTerm;
            IncludePreRelease = includePreRelease;
            Format = format;
        }

        [Value(0,
            Required = true,
            MetaName = "search term(s)",
            HelpText = "One or more terms to search for in the NuGet Gallery.")]
        public string SearchTerm { get; }

        [Option('p', "prerelease",
            HelpText = "Indicates whether to include pre-release versions of the package.")]
        public bool IncludePreRelease { get; }

        [Option('f', "format",
            HelpText = "Indicates which format to output the results in.",
            Default = "Console")]
        public string Format { get; }

        public static Arguments Parse(IEnumerable<string> args)
        {
            var result = Parser.Default.ParseArguments<Arguments>(args);

            switch (result)
            {
                case Parsed<Arguments> options:
                    return options.Value;
                case NotParsed<Arguments> options:
                    throw new ArgumentException(string.Join("\\n", options.Errors));
                default: return default;
            }
        }
    }
}
