using System.Collections.Generic;
using WindowsFormsApplication1.Enums;

namespace WindowsFormsApplication1.Entities
{

    public class Event : Subject
    {
        private int _eventId;
        private string _name;
        private PriorityTypes _priorityType;

        public Event(int eventId, string name, PriorityTypes priorityType)
        {
            this._name = name;
            this._priorityType = priorityType;
        }

        public int EventId
        {
            get
            {
                return _eventId;
            }

            set
            {
                _eventId = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public PriorityTypes PriorityType
        {
            get
            {
                return _priorityType;
            }

            set
            {
                _priorityType = value;
            }
        }


        //public void Copy
    }
}
