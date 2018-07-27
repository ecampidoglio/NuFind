using System;
using Microsoft.Extensions.CommandLineUtils;

namespace NuFind.Extensions
{
    public static class CommandLineExtensions
    {
        public static SearchOptions ParseSearchOptions(this string[] args)
        {
            var options = new CommandLineApplication();

            var searchTerm = options.Argument(
                "searchTerm",
                "The term to search for in the NuGet Gallery.");
            var includePrerelease = options.Option(
                "-p | --prerelease",
                "Indicates whether to include pre-release versions of the package.",
                CommandOptionType.NoValue);
            options.HelpOption("-h | --help");

            try
            {
                options.Execute(args);

                return new SearchOptions(
                    searchTerm.Value,
                    includePrerelease.HasValue());
            }
            catch (CommandParsingException e)
            {
                throw new ArgumentException(e.Message);
            }
        }
    }
}