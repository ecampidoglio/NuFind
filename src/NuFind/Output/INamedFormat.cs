namespace NuFind.Output
{
    public interface INamedFormat : IFormat
    {
        string Name { get; }
    }
}
