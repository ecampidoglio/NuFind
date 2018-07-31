using NuFind.CommandLine;
using NuFind.Search;

namespace NuFind
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Arguments.Parse(args)
                .SearchPackages()
                .ParseMetadata()
                .PrintResults();
        }
    }
}
