using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Xml.Linq;
using NuFind.CommandLine;

namespace NuFind.Search
{
    internal static class NuGetApiExtensions
    {
        internal static XDocument SearchPackages(this Arguments options)
        {
            using (var client = NuGetApiClient())
            {
                var response = client.GetStringAsync(options.ToNuGetSearchQuery()).Result;
                return XDocument.Parse(response);
            }
        }

        internal static IEnumerable<PackageMetadata> ParseMetadata(this XDocument packages)
        {
            XNamespace md = "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata";
            XNamespace ds = "http://schemas.microsoft.com/ado/2007/08/dataservices";

            return packages
                .Descendants(md + "properties")
                .Select(node =>
                    new PackageMetadata(
                        (string)node.Element(ds + "Id"),
                        (string)node.Element(ds + "Version"),
                        (string)node.Element(ds + "Authors"),
                        (string)node.Element(ds + "Description"),
                        new Uri(node.Element(ds + "IconUrl").ValueOrDefault("https://www.nuget.org/Content/gallery/img/default-package-icon.svg")),
                        new Uri((string)node.Element(ds + "GalleryDetailsUrl")),
                        (bool)node.Element(ds + "IsPrerelease")))
                .OrderBy(node => node.Id);
        }

        private static HttpClient NuGetApiClient()
        {
            return new HttpClient
            {
                BaseAddress = new Uri("https://www.nuget.org/api/v2/")
            };
        }

        private static string ToNuGetSearchQuery(this Arguments options)
        {
            var includePrerelease = options
                .IncludePreRelease
                .ToString()
                .ToLower();
            return $"Search()?searchTerm='{options.SearchTerm}'&includePrerelease={includePrerelease}";
        }
    }
}
