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
            Uri iconUrl = null,
            Uri galleryUrl = null,
            bool isPreRelease = false)
        {
            Id = id;
            Version = version;
            Authors = authors;
            Description = description;
            IconUrl = iconUrl;
            GalleryUrl = galleryUrl;
            IsPreRelease = isPreRelease;
        }

        public string Id { get; }

        public string Version { get; }

        public string Authors { get; }

        public string Description { get; }

        public Uri IconUrl { get; }

        public Uri GalleryUrl { get; }

        public bool IsPreRelease { get; }
    }
}
