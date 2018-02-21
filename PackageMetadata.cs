namespace NuFind
{
    internal struct PackageMetadata
    {
        public PackageMetadata(
            string id,
            string version,
            string authors,
            bool isPreRelease = false)
        {
            Id = id;
            Version = version;
            Authors = authors;
            IsPreRelease = isPreRelease;
        }

        public string Id { get; }

        public string Version { get; }

        public string Authors { get; }

        public bool IsPreRelease { get; }
    }
}
