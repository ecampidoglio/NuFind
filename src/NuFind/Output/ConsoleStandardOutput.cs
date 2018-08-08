using System;

namespace NuFind.Output
{
    public class ConsoleStandardOutput : IOutput
    {
        public void Send(string text)
        {
            Console.Out.Write(text);
        }
    }
}
