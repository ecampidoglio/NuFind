using System.Xml.Linq;

namespace NuFind.Search
{
    internal static class XmlExtensions
    {
        internal static string ValueOrDefault(this XNode node, string defaultValue)
        {
            if (node is XElement element && !element.IsEmpty)
            {
                return element.Value;
            }

            return defaultValue;
        }
    }
}
