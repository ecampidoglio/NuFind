using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using NuFind.Search;

namespace NuFind.Output
{
    public class AlfredJsonFormat : INamedFormat
    {
        public string Name => "Alfred";

        public string Render(IEnumerable<PackageMetadata> packages)
        {
            var results = new
            {
                items = packages.Select(FormatAlfredResult)
            };

            return JsonConvert.SerializeObject(results);
        }

        private static object FormatAlfredResult(PackageMetadata p) =>
            new
            {
                title = p.Id,
                subtitle = $"{p.Version} • {p.Authors}",
                arg = ClipboardText(p),
                autocomplete = p.Id,
                quicklookurl = p.GalleryUrl.AbsoluteUri,
                icon = new
                {
                    path = "icon.png"
                }
            };

        private static string ClipboardText(PackageMetadata p) =>
            $"<PackageReference Include=\"{p.Id}\" Version=\"{p.Version}\" />";
    }
}
