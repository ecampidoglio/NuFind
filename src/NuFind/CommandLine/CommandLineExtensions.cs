using System.Collections.Generic;

namespace NuFind.CommandLine
{
    public static class CommandLineExtensions
    {
        public static Arguments Parse(this IEnumerable<string> args)
        {
            return Arguments.Parse(args);
        }
    }
}
