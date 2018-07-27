using CommandLine;

namespace NuFind
{
    public class SearchOptions
    {
        [Value(0,
            Required = true,
            HelpText = "The term to search for in the NuGet Gallery.")]
        public string SearchTerm { get; set; }

        [Option('p', "prerelease",
            HelpText = "Indicates whether to include pre-release versions of the package.")]
        public bool IncludePreRelease { get; set; }
    }
}
