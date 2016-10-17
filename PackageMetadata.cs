namespace NuFind
{
    internal struct PackageMetadata
    {
        public PackageMetadata(
            string id,
            string version,
            bool isPreRelease = false)
        {
            Id = id;
            Version = version;
            IsPreRelease = isPreRelease;
        }

        public string Id { get; }

        public string Version { get; }

        public bool IsPreRelease { get; }
    }
}
