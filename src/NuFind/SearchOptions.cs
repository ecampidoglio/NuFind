namespace NuFind
{
    public struct SearchOptions
    {
        public SearchOptions(string searchTerm, bool includePreRelease)
        {
            SearchTerm = searchTerm;
            IncludePreRelease = includePreRelease;
        }

        public string SearchTerm { get; }

        public bool IncludePreRelease { get; }
    }
}
