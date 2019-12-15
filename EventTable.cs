using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using WindowsFormsApplication1.Entities;

namespace WindowsFormsApplication1
{
    public class EventTable
    {
        private static EventTable instance = null;
        private static readonly object Instancelock = new object();
        private ConcurrentBag<Event> _table = new ConcurrentBag<Event>();

        public static EventTable GetInstance
        {
            get
            {
                if (instance == null)
                {
                    lock (Instancelock)
                    {
                        if (instance == null)
                        {
                            instance = new EventTable();
                        }
                    }
                }
                return instance;
            }
        }

        public async Task Put(Event e)
        {
            await Task.Delay(3000);
            _table.Add(e);
        }

        public Event Read(int index)
        {
            var result = _table.ElementAtOrDefault(index);

            return result;
        }

    }
}
