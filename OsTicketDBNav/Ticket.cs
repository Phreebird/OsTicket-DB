using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsTicketDBNav
{
    public class Ticket : TicketStub
    {
        public Ticket() : base()
        {
            
        }
        public Message[] ticketResponses { get; set; }

    }
}
