using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace OsTicketDBNav
{
    public class Events
    {
        private enum ticketStates { CREATED, OVERDUE, CLOSED, REOPENED, ASSIGNED, TRANSFERRED }
        private string[] eventTypes = { "CREATED", "OVERDUE", "CLOSED", "REOPENED", "ASSIGNED", "TRANSFERRED" };
        public void AddCloseTicketEvent(MySqlConnection db, TicketStub stub)
        {
            string insertCloseEventString = string.Format("INSERT INTO `dfgrimes_stck1`.`ost_ticket_event` (`ticket_id`, `staff_id`, `team_id`, `dept_id`, `topic_id`, `state`, `staff`, `annulled`, `timestamp`) VALUES ('{0}', '{1}', '999', '999', '999', 'closed', 'SYSTEM TA', '0', '" + DateTime.Now.ToString("yyyy-MM-dd h:mm:tt") + "')", )
                // ("INSERT INTO `dfgrimes_stck1`.`ost_ticket_event` (`ticket_id`, `staff_id`, `team_id`, `dept_id`, `topic_id`, `state`, `staff`, `annulled`, `timestamp`) VALUES ('{0}', '{1}', '999', '999', '999', 'closed', 'SYSTEM TA', '0', '" + DateTime.Now.ToString("yyyy-MM-dd h:mm:tt") + "')";
            MySqlCommand insertCloseEvent = new MySqlCommand(insertCloseEventString, db);
        }
    }
}
