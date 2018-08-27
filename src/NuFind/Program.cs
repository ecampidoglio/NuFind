using System;
using NuFind.CommandLine;
using NuFind.Output;
using NuFind.Search;

namespace NuFind
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            try
            {
                args.Parse()
                    .SearchPackages()
                    .PrintResults();

                return ExitStatus.Success;
            }
            catch (ArgumentException)
            {
                return ExitStatus.UsageError;
            }
        }
    }
}
