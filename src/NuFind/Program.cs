using NuFind.CommandLine;
using NuFind.Search;

namespace NuFind
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            SearchOptions.Parse(args)
                .SearchPackages()
                .ParseMetadata()
                .PrintResults();
        }
    }
}
