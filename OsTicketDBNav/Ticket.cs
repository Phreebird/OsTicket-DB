using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsTicketDBNav
{
    public class Ticket : TicketStub
    {
        public Ticket()  {}
        public Ticket(TicketStub stub)
        {
            this.trueNumber = stub.trueNumber;
            this.number = stub.number;
            this.subject = stub.subject;
            this.creatorUserId = stub.creatorUserId;
            this.priority = stub.priority;
            this.isOpen = stub.isOpen;
            this.company = stub.company;
            this.creationDate = stub.creationDate;
            this.lastResponse = stub.lastResponse;
        }
        public List<Message> responses { get; set; }
    }
}
