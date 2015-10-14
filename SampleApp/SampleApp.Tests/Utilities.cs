using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SampleApp.Tests
{
    public class Utilities
    {
        public static void WaitFor(int milliseconds)
        {
            Thread.Sleep(milliseconds);
        }

        public static void WaitFor(Func<bool> condition, int milliseconds)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            while (!condition() && stopwatch.ElapsedMilliseconds < milliseconds)
            { 
            }
        }
    }
}
