using System.Collections.ObjectModel;
using System.Linq;

namespace NuFind.Output
{
    public class AvailableFormats : ReadOnlyCollection<INamedFormat>
    {
        public AvailableFormats() : base(Formats())
        {
        }

        public INamedFormat ByName(string name)
        {
            return this.Single(f => f.Name.EqualsCaseInsensitive(name));
        }

        private static INamedFormat[] Formats() =>
            new INamedFormat[]
            {
                new ColoredConsoleFormat(),
                new AlfredJsonFormat()
            };
    }
}
