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
                subtitle = p.Description,
                arg = ClipboardText(p),
                autocomplete = p.Id,
                quicklookurl = p.GalleryUrl.AbsoluteUri,
                text = new
                {
                    copy = ClipboardText(p)
                },
                mods = new
                {
                    alt = new
                    {
                        valid = true,
                        arg = $"{p.Version} • {p.Authors} • {p.DownloadCount} downloads",
                        subtitle = $"{p.Version} • {p.Authors} • {p.DownloadCount} downloads"
                    },
                    cmd = new
                    {
                        valid = true,
                        arg = p.GalleryUrl.AbsoluteUri,
                        subtitle = $"Go to {p.GalleryUrl.AbsoluteUri}"
                    }
                },
                icon = new
                {
                    path = "icon.png"
                }
            };

        private static string ClipboardText(PackageMetadata p) =>
            $"<PackageReference Include=\"{p.Id}\" Version=\"{p.Version}\" />";
    }
}
