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
        public static void AddCloseTicketEvent(MySqlConnection db, string dbName, TicketStub stub)
        {
            //TODO: Get rid of dfgrimes                                         HERE
            string insertCloseEventString = string.Format(@"INSERT INTO `{0}`.`ost_ticket_event` 
                (`ticket_id`, `staff_id`, `team_id`, `dept_id`, `topic_id`, `state`, `staff`, `annulled`, `timestamp`) 
                VALUES ('" + stub.ticketTrueNumber + "', '-1', '0', '1', '0', 'closed', 'SYSTEM', '0', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:tt") + "')", dbName);                
            MySqlCommand insertCloseEvent = new MySqlCommand(insertCloseEventString, db);
            try
            {
                if (insertCloseEvent.ExecuteNonQuery() != 1)
                    throw new Exception();
            }
            catch(Exception)
            {
                throw;
            }
        }
        public static void AddOpenedTicketEvent(MySqlConnection db, string dbName, TicketStub stub)
        {
            //TODO: Get rid of dfgrimes                                         HERE
            string insertCloseEventString = string.Format(@"INSERT INTO `{0}`.`ost_ticket_event` 
                (`ticket_id`, `staff_id`, `team_id`, `dept_id`, `topic_id`, `state`, `staff`, `annulled`, `timestamp`) 
                VALUES ('" + stub.ticketTrueNumber + "', '-1', '0', '1', '0', 'created', 'SYSTEM TAPP', '0', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:tt") + "')", dbName);
            MySqlCommand insertOpenEvent = new MySqlCommand(insertCloseEventString, db);
            try
            {
                if (insertOpenEvent.ExecuteNonQuery() != 1)
                    throw new Exception();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
