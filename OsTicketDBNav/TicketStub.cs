using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsTicketDBNav
{
    public class TicketStub
    {
        public TicketStub() { }
        public override String ToString()
        {
            return "Ticket ID:" + number + " Ticket Subject:" + subject;
        }
        //TODO: Add sophisticaed constructor
        public int trueNumber { get; set; }
        public int deparmentId { get; set; }
        public int number { get; set; }
        public String subject { get; set; }      
        public int creatorUserId { get; set; }
        public int closerUserId { get; set; }
        public int priority { get; set; }
        public Boolean isOpen { get; set; }
        public String company { get; set; }
        public DateTime creationDate { get; set; }
        public DateTime lastResponse { get; set; }
    }
}
