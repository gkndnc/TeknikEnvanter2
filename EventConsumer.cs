using System;
using System.Threading;
using System.Threading.Tasks;
using WindowsFormsApplication1.Entities;
using WindowsFormsApplication1;

namespace WindowsFormsApplication1
{
    public class EventConsumer : Observer
    {
        public int completedCount = 0;

        public override void Alert(Event e1, Event e2, Event e3)
        {
            new TaskFactory().StartNew(async () =>
            {
                await Task.Delay(5000);
                Interlocked.Increment(ref completedCount);
                if (e1.PriorityType == e2.PriorityType && e2.PriorityType == e3.PriorityType)
                {
                    Logger.LogInfo(string.Format("Alerted {0}-{1}-{2}", e1.Name, e2.Name, e3.Name));
                }
                else
                {
                    Logger.LogInfo(string.Format("Not Alerted {0}-{1}-{2}", e1.Name, e2.Name, e3.Name));
                }
            });
        }
    }
}
