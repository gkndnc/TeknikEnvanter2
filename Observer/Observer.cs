using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication1.Entities;

namespace WindowsFormsApplication1
{
    public abstract class Observer
    {
        public abstract void Alert(Event e1, Event e2, Event e3);
    }
}
