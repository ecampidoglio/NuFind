using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Xml.Linq;

namespace NuFind
{
    internal static class NuGetApiExtensions
    {
        internal static XDocument SearchPackages(this SearchOptions options)
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
                        (bool)node.Element(ds + "IsPrerelease")))
                .OrderBy(node => node.Id);
        }

        private static HttpClient NuGetApiClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://www.nuget.org/api/v2/");
            return client;
        }

        private static string ToNuGetSearchQuery(this SearchOptions options)
        {
            var includePrerelease = options
                .IncludePreRelease
                .ToString()
                .ToLower();
            return $"Search()?searchTerm='{options.SearchTerm}'&includePrerelease={includePrerelease}";
        }
    }
}