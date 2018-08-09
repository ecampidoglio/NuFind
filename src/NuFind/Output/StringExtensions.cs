using System;

namespace NuFind.Output
{
    internal static class StringExtensions
    {
        internal static bool EqualsCaseInsensitive(
            this string source,
            string value)
        {
            return string.Equals(
                source,
                value,
                StringComparison.OrdinalIgnoreCase);
        }
    }
}
