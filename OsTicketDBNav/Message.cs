using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsTicketDBNav
{
    public class Message
    {
        public Message(String posterName, String messageSubject, String messageData)
        {
            this.messageData = messageData;
            this.posterName = posterName;
            this.messageTitle = messageTitle;
            this.timeRecieved = DateTime.Now;
        }
        public Message() { }
        public String messageTitle { get; set; }
        public String messageData { get; set; }
        public char threadType { get; set; }
        public String posterName { get; set; }
        public int responseNumber { get; set; }
        public DateTime timeRecieved { get; set; }
    }
}
