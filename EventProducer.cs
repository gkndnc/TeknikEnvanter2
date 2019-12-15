using System;
using System.Threading;
using System.Threading.Tasks;
using WindowsFormsApplication1.Entities;
using WindowsFormsApplication1.Enums;

namespace WindowsFormsApplication1
{
    public class EventProducer
    {
        private EventConsumer consumer;

        public int EventCount = 0;

        public EventProducer(EventConsumer consumer)
        {
            this.consumer = consumer;
        }

        public void Produce()
        {
            new TaskFactory().StartNew(async () => {
                Event e1 = GenerateRandomEvent(0);
                await PutEvent(e1);
                Event e2 = GenerateRandomEvent(1);
                await PutEvent(e2);

                for (int i = 2; i < 400; i++)
                {
                    Event e3 = GenerateRandomEvent(i);
                    e3.Attach(consumer);

                    await PutEvent(e3);

                    e3.Notify(e1, e2, e3);

                    e1 = e2;
                    e2 = e3;
                }
            }, TaskCreationOptions.LongRunning);
        }



        private async Task PutEvent(Event evt)
        {
            await EventTable.GetInstance.Put(evt);
            Interlocked.Increment(ref EventCount);
        }

        private Event GenerateRandomEvent(int index)
        {
            var rand = new Random();
            Event evt = new Event(index, "E" + index.ToString(), (PriorityTypes)rand.Next(1, 4));
            Console.WriteLine("Procuded: " + evt.Name + " - " + evt.PriorityType);

            return evt;
        }


    }
}
