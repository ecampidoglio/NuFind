namespace NuFind.Output
{
    public class AlfredPrinter : Printer
    {
        public AlfredPrinter()
            : base(new AlfredJsonFormat(), new ConsoleStandardOutput())
        {
        }
    }
}
