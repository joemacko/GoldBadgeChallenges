using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Outings_Repo
{
    public enum EventType
    {   
        AmusementPark = 1,
        Bowling,
        Concert,
        Golf
    }
    public class Outing
    {
        public int Id { get; set; }
        public EventType EventType { get; set; }
        public string OutingName { get; set; }
        public int NumAttended { get; set; }
        public DateTime EventDate { get; set; }
        public decimal CostPerson { get; set; }
        public decimal CostEvent { get; set; }

        public Outing() { }

        public Outing(int id, EventType eventType, string outingName, int numAttended, DateTime eventDate, decimal costPerson, decimal costEvent)
        {
            Id = id;
            EventType = eventType;
            OutingName = outingName;
            NumAttended = numAttended;
            EventDate = eventDate;
            CostPerson = costPerson;
            CostEvent = costEvent;
        }
    }
}
