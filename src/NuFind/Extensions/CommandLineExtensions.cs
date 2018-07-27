using System;
using System.Collections.Generic;
using CommandLine;

namespace NuFind.Extensions
{
    public static class CommandLineExtensions
    {
        public static SearchOptions ParseSearchOptions(
            this IEnumerable<string> args)
        {
            var result = Parser.Default.ParseArguments<SearchOptions>(args);

            switch (result)
            {
                case Parsed<SearchOptions> options:
                    return options.Value;
                case NotParsed<SearchOptions> options:
                    throw new ArgumentException(string.Join("\\n", options.Errors));
                default: return default(SearchOptions);
            }
        }
    }
}
