using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace AD_Lib.Performance
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
        private IntPtr processorAffinity;
        private bool affinityLocked;

        /// <summary>
        /// Creates a new PerformanceCounter.
        /// </summary>
        /// <exception cref="QueryPerformanceCounterException"></exception>
        public PerformanceCounter()
        {
            if(!QueryPerformanceFrequency(out frequency))
            {
                // Should never happen on Windows XP or later according to MSDN
                throw new QueryPerformanceCounterException("QueryPerformanceCounter not supported on this machine.");
            }
        }

        /// <summary>
        /// Locks the current process' processor affinity to the last available processor.
        /// Can be used to optimize testing conditions.
        /// </summary>
        public void lockAffinity()
        {
            if(affinityLocked)
                return;

            var process = Process.GetCurrentProcess();
            // Store existing affinity.
            processorAffinity = process.ProcessorAffinity;

            // Create an affinity mask that only allows the highest number processor on this system and apply it.
            IntPtr lockedAffinity = (IntPtr)(0x1 << Environment.ProcessorCount - 1);
            process.ProcessorAffinity = lockedAffinity;

            affinityLocked = true;
        }

        /// <summary>
        /// Restores this process' processor affinity to its previous value if it's currently locked.
        /// </summary>
        public void releaseAffinity()
        {
            if(!affinityLocked)
                return;

            Process.GetCurrentProcess().ProcessorAffinity = processorAffinity;
            affinityLocked = false;
        }

        /// <summary>
        /// Start the performance counter.
        /// GC and a thread sleep are executed before the measurement takes place.
        /// </summary>
        public void startCounter()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();

            // Do we need this here or does GC.WaitForPendingFinalizers() already put us back in the ready queue?
            Thread.Sleep(1);

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


    [Serializable]
    public class QueryPerformanceCounterException : Exception
    {
        public QueryPerformanceCounterException() { }
        public QueryPerformanceCounterException(string message) : base(message) { }
        public QueryPerformanceCounterException(string message, Exception inner) : base(message, inner) { }
        protected QueryPerformanceCounterException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
