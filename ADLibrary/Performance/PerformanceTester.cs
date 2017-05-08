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
        /// <summary>
        /// Used for locking during test runs.
        /// It is static to ensure locking between all PerformanceTester objects since they all want to run on the same core.
        /// </summary>
        static object staticLock = new object();
        /// <summary>
        /// Our performance counter.
        /// </summary>
        PerformanceCounter pfc;
        /// <summary>
        /// The action to test.
        /// </summary>
        Action action;
        /// <summary>
        /// Callback to invoke when done testing. Test time in us is passed.
        /// </summary>
        Action<long> callback;
        /// <summary>
        /// The last test time in us.
        /// </summary>
        long lastRunTime;
        /// <summary>
        /// The currently running test thread. Null if no thread is running.
        /// </summary>
        Thread testThread;

        /// <summary>
        /// Creates a new PerformanceTester for the given action. The callback is invoked upon completion.
        /// Call run() to start the test.
        /// Callback will be invoked from the test thread.
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
        /// Aborts and waits for the test thread to finish.
        /// Should be called from UI thread before closing the form.
        /// </summary>
        public void abort()
        {
            if(testThread != null)
            {
                testThread.Abort();
                testThread.Join();
            }
        }

        /// <summary>
        /// Starts the test thread.
        /// </summary>
        public void run()
        {
            Thread thread = new Thread(new ThreadStart(threadRun));
            thread.Priority = ThreadPriority.Highest;                       // Give high priority to the test thread
            thread.Start();
            testThread = thread;                                            // Allow aborting
        }

        /// <summary>
        /// The test thread.
        /// </summary>
        private void threadRun()
        {
            lock(staticLock)                                // Lock to prevent other threads from messing with our test
            {
                setThreadProcessorAffinity();               // Set affinity to last processor
                GC.Collect();                               // GC now to prevent it from happening during the test
                GC.WaitForPendingFinalizers();
                
                Thread.Sleep(1);                            // Go back to ready queue?

                pfc.startCounter();                         // Start the timer
                action.Invoke();                            // Invoke the action that should be timed
                lastRunTime = pfc.stopCounter(TimerResult.Microseconds);            // Stop the timer and store result
            }

            testThread = null;                              // Prevent aborting
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
            // Set the thread's processor affinity to the last processor
            thread.ProcessorAffinity = new IntPtr(1 << (Environment.ProcessorCount - 1));
        }
    }
}
