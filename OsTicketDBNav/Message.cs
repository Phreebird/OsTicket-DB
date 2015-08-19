using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsTicketDBNav
{
    public class Message
    {
        public Message(String posterName, String messageSubject, String messageData, DateTime timeRecieved)
        {
            this.messageData = messageData;
            this.posterName = posterName;
            this.messageSubject = messageSubject;
            this.timeRecieved = timeRecieved;
        }
        public Message() { }
        public String messageTitle { get; set; }
        public String messageData { get; set; }
        public char threadType { get; set; }
        public String posterName { get; set; }
        public int responseNumber { get; set; }
        public String messageSubject { get; set; }
        public DateTime timeRecieved { get; set; }
    }
}
