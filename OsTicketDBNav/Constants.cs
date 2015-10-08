using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsTicketDBNav
{
    class Constants
    {
        //Hard Coded Querys
        public static string pullOpenTicketsQuery = "SELECT * FROM `ost_ticket` WHERE `status_id` = 1;";
        public static string pullOpenTicketDataQuery = "SELECT * FROM `ost_ticket__cdata`;";

        //Colloum Name
        public static string tableTicketID = "ticket_id";
        public static string tableTicketNumber = "number";
        public static string tableUserID = "user_id";
        public static string tableDeptID = "dept_id";
        public static string lastMessage = "lastmessage";
        public static string creationDate = "created";
        public static string subject = "subject";
        public static string priority = "priority";
    }
}
