using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace ADLibrary.Performance
{
    public class PerformanceCounter
    {
        // QPC is in an external unmanaged dll
        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceCounter(out long lpPerformanceCount);
        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceFrequency(out long lpFrequency);

        private long frequency;
        private long start;

        /// <summary>
        /// Creates a new PerformanceCounter.
        /// </summary>
        /// <exception cref="QueryPerformanceCounterException"></exception>
        public PerformanceCounter()
        {
            if(!QueryPerformanceFrequency(out frequency))
            {
                // Should never happen on Windows XP or later according to MSDN
                throw new Win32Exception("QueryPerformanceCounter not supported on this machine.");
            }
        }

        /// <summary>
        /// Start the performance counter.
        /// GC and a thread sleep are executed before the measurement takes place.
        /// </summary>
        public void startCounter()
        {
            QueryPerformanceCounter(out start);
        }

        /// <summary>
        /// Ends the performance counter and returns the elapsed time in the passed unit.
        /// </summary>
        /// <param name="result">The unit of time the returned result should be in.</param>
        /// <returns>Time since startCounter was last called.</returns>
        public long stopCounter(TimerResult result = TimerResult.Milliseconds)
        {
            long end;
            QueryPerformanceCounter(out end);
            long delta = end - start;

            // Multiply the delta to get the requested time unit since frequency is per second.
            if(result == TimerResult.Microseconds)
            {
                delta *= 1000000;
            }
            else if(result == TimerResult.Milliseconds)
            {
                delta *= 1000;
            }
            else
            {
                throw new ArgumentException("Unknown TimerResult value.");
            }

            // Divide by frequency to get elapsed time.
            delta /= frequency;

            return delta;
        }
    }

    public enum TimerResult
    {
        Milliseconds,
        Microseconds
    }
}
