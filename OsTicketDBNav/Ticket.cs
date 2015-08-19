using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsTicketDBNav
{
    public class Ticket : TicketStub
    {
        public Ticket()
        {
            
        }
        public Ticket(TicketStub stub)
        {
            this.ticketTrueNumber = stub.ticketTrueNumber;
            this.ticketNumber = stub.ticketNumber;
            this.ticketSubject = stub.ticketSubject;
            this.creatorUserId = stub.creatorUserId;
            this.ticketPriority = stub.ticketPriority;
            this.isOpen = stub.isOpen;
            this.ticketCompany = stub.ticketCompany;
            this.ticketCreationDate = stub.ticketCreationDate;
            this.ticketCreationDate = stub.ticketLastResponse;
        }
        public List<Message> ticketResponses { get; set; }
    }
}
