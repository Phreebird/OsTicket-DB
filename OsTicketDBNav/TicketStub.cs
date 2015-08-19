using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsTicketDBNav
{
    class TicketStub
    {
        public TicketStub() { }
        public String toString()
        {
            return "";
        }
        //TODO: Add sophisticaed constructor
        public String ticketSubject { get; set; }
        public int ticketNumber { get; set; }
        public int ticketTrueNumber { get; set; }
        public String creatorUserName { get; set; }
        public String creatorIpAddress { get; set; }
        public int ticketPriority { get; set; }
        public Boolean isOpen { get; set; }
        public String ticketCompany { get; set; }
        public DateTime ticketCreationDate { get; set; }
        public DateTime ticketLastResponse { get; set; }
    }
}
