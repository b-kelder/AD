using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ADLibrary.Performance
{
    public class PerformanceTester
    {
        PerformanceCounter pfc;
        Action action;
        Action<long> callback;
        long lastRunTime;

        public PerformanceTester(Action actionToTest, Action<long> callback)
        {
            action = actionToTest;
            this.callback = callback;
            pfc = new PerformanceCounter();
        }

        public void run()
        {
            Thread thread = new Thread(new ThreadStart(threadRun));
            thread.Priority = ThreadPriority.Highest;
            thread.Start();
        }

        private void threadRun()
        {
            setThreadProcessorAffinity();
            lock(action)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();

                pfc.startCounter();
                action.Invoke();
                lastRunTime = pfc.stopCounter();
            }

            callback.Invoke(lastRunTime);
        }

        public long getLastRunTime()
        {
            return lastRunTime;
        }

        private void setThreadProcessorAffinity()
        {
#pragma warning disable 618
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
