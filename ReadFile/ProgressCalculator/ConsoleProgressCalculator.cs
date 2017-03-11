using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadFile
{
    public class ConsoleProgressCalculator : IProgressCalculator
    {

        public void ShowProgress(long processed, long total)
        {
            long percent = (100 * (processed + 1)) / total;
            Console.SetCursorPosition(1, 0);
            string message = String.Format("Progress : {0} %", percent);
            Console.Write(message, percent);
        }
    }
}
