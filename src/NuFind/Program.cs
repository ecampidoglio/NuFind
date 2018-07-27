using NuFind.Extensions;

namespace NuFind
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            args
                .ParseSearchOptions()
                .SearchPackages()
                .ParseMetadata()
                .PrintResults();
        }
    }
}
