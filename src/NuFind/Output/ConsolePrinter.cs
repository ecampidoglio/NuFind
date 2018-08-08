namespace NuFind.Output
{
    public class ConsolePrinter : Printer
    {
        public ConsolePrinter()
            : base(new ColoredConsoleFormat(), new ConsoleStandardOutput())
        {
        }
    }
}
