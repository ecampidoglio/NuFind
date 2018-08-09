using NuFind.CommandLine;
using NuFind.Output;
using NuFind.Search;

namespace NuFind
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            args.Parse()
                .SearchPackages()
                .PrintResults();
        }
    }
}
