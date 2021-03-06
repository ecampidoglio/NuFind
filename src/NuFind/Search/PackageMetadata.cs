using System;

namespace NuFind.Search
{
    public struct PackageMetadata
    {
        public PackageMetadata(
            string id,
            string version,
            string authors,
            string description,
            long downloadCount,
            Uri iconUrl = null,
            Uri galleryUrl = null,
            bool isPreRelease = false)
        {
            Id = id;
            Version = version;
            Authors = authors;
            Description = description;
            DownloadCount = downloadCount;
            IconUrl = iconUrl;
            GalleryUrl = galleryUrl;
            IsPreRelease = isPreRelease;
        }

        public string Id { get; }

        public string Version { get; }

        public string Authors { get; }

        public string Description { get; }

        public long DownloadCount { get; }

        public Uri IconUrl { get; }

        public Uri GalleryUrl { get; }

        public bool IsPreRelease { get; }
    }
}
