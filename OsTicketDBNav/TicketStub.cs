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
            return "Ticket ID:" + ticketNumber + " Ticket Subject:" + ticketSubject;
        }
        //TODO: Add sophisticaed constructor
        public int ticketTrueNumber { get; set; }
        public int ticketNumber { get; set; }
        public String ticketSubject { get; set; }      
        public int creatorUserId { get; set; }
        public int ticketPriority { get; set; }
        public Boolean isOpen { get; set; }
        public String ticketCompany { get; set; }
        public DateTime ticketCreationDate { get; set; }
        public DateTime ticketLastResponse { get; set; }
    }
}
