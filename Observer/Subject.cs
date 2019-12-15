using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication1.Entities;
using WindowsFormsApplication1;

namespace WindowsFormsApplication1
{
    public abstract class Subject
    {
        private List<Observer> _observers = new List<Observer>();

        public void Attach(Observer observer)
        {
            _observers.Add(observer);
        }

        public void Detach(Observer observer)
        {
            _observers.Remove(observer);
        }

        public void Notify(Event e1, Event e2, Event e3)
        {
            foreach (Observer o in _observers)
            {
                o.Alert(e1, e2, e3);
            }
        }
    }
}
