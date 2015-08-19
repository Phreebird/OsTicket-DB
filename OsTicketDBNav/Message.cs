using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsTicketDBNav
{
    class Message
    {
        public Message(String userName, String messageSubject, String messageData, DateTime timeRecieved)
        {
            this.messageData = messageData;
            this.userName = userName;
            this.messageSubject = messageSubject;
            this.timeRecieved = timeRecieved;
        }
        public String messageData { get; set; }
        public String userName { get; set; }
        public String messageSubject { get; set; }
        public DateTime timeRecieved { get; set; }
    }
}
