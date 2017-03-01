using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ADLibrary.Performance
{
    /// <summary>
    /// Class for testing the time an Action takes to complete.
    /// </summary>
    public class PerformanceTester
    {
        PerformanceCounter pfc;
        Action action;
        Action<long> callback;
        long lastRunTime;

        /// <summary>
        /// Creates a new PerformanceTester for the given action. The callback is invoked upon completion.
        /// Invoke run() to start the test.
        /// Callback will be invoked from a different thread.
        /// </summary>
        /// <param name="actionToTest">The action to time</param>
        /// <param name="callback">The callback to invoke upon completion</param>
        public PerformanceTester(Action actionToTest, Action<long> callback)
        {
            action = actionToTest;
            this.callback = callback;
            pfc = new PerformanceCounter();
        }

        /// <summary>
        /// Returns the last timing result.
        /// </summary>
        /// <returns></returns>
        public long getLastRunTime()
        {
            return lastRunTime;
        }

        /// <summary>
        /// Starts the test thread.
        /// </summary>
        public void run()
        {
            Thread thread = new Thread(new ThreadStart(threadRun));
            thread.Priority = ThreadPriority.Highest;                       // Give high priority to the test thread
            thread.Start();
        }

        /// <summary>
        /// The test thread.
        /// </summary>
        private void threadRun()
        {
            lock(action)                                    // Lock to prevent other threads from messing with our test
            {
                setThreadProcessorAffinity();               // Set affinity to last processor
                GC.Collect();                               // GC now to prevent it from happening during the test
                GC.WaitForPendingFinalizers();
                // Should we do a Thread.Sleep(1) here to put it back in the queue and maximise the time until we get interrupted?

                pfc.startCounter();                         // Start the timer
                action.Invoke();                            // Invoke the action that should be timed
                lastRunTime = pfc.stopCounter();            // Stop the timer and store result
            }

            callback.Invoke(lastRunTime);                   // Invoke callback to indicate we are done
        }

        /// <summary>
        /// Sets the processor affinity for the calling thread to the last processor in the system.
        /// </summary>
        private void setThreadProcessorAffinity()
        {
            // Disable the deprecated warning because it still works.
#pragma warning disable 618
            // Get thread id
           int osThreadId = AppDomain.GetCurrentThreadId();
#pragma warning restore 618

            // Find the ProcessThread for this thread.
            ProcessThread thread = Process.GetCurrentProcess().Threads.Cast<ProcessThread>()
                                       .Where(t => t.Id == osThreadId).Single();
            // Set the thread's processor affinity
            thread.ProcessorAffinity = new IntPtr(1 << (Environment.ProcessorCount - 1));
        }
    }
}
