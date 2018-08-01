using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml.Linq;

namespace NuFind.Search
{
    public class NuGetPackageFeedV2
    {
        public IEnumerable<PackageMetadata> Search(string keywords, bool includePreRelease = false)
        {
            using (var client = NuGetV2ApiClient())
            {
                var response = client.DownloadString(
                    $"Search?searchTerm='{keywords}'&includePrerelease={includePreRelease}");
                return Parse(response);
            }
        }

        private static WebClient NuGetV2ApiClient() =>
            new WebClient { BaseAddress = "https://www.nuget.org/api/v2/" };

        private static IEnumerable<PackageMetadata> Parse(string feed)
        {
            XNamespace md = "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata";
            XNamespace ds = "http://schemas.microsoft.com/ado/2007/08/dataservices";

            return XDocument
                .Parse(feed)
                .Descendants(md + "properties")
                .Select(node =>
                    new PackageMetadata(
                        (string)node.Element(ds + "Id"),
                        (string)node.Element(ds + "Version"),
                        (string)node.Element(ds + "Authors"),
                        (string)node.Element(ds + "Description"),
                        new Uri(node.Element(ds + "IconUrl").ValueOrDefault(
                            "https://www.nuget.org/Content/gallery/img/default-package-icon.svg")),
                        new Uri((string)node.Element(ds + "GalleryDetailsUrl")),
                        (bool)node.Element(ds + "IsPrerelease")));
        }
    }
}
