using System;
using System.Threading.Tasks;

namespace ReadFile
{
    /// <summary>
    /// This class methods for write message on Console, Implements IWriter interface
    /// </summary>
    public class ConsoleWriter : IWriter
    {
        public void Write(string message)
        {
            Console.Write(message);
        }
    }
}