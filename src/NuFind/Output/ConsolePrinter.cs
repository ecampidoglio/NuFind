namespace NuFind.Output
{
    public class ConsolePrinter : Printer
    {
        public ConsolePrinter(IFormat format)
            : base(format, new ConsoleStandardOutput())
        {
        }
    }
}
