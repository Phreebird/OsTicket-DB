using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace OsTicketDBNav
{
    public class DatabaseHelper
    {
        private string connectionString;
        public DatabaseHelper(String dbServer, String dbName, String dbUser, String dbPassword)
        {
            this.connectionString = "Server=" + dbServer + ";Database=" + dbName + ";Uid=" + dbUser + ";Pwd=" + dbPassword + ";" + "Convert Zero Datetime=True";
        }
        public List<TicketStub> PullOpenTickets()
        {
            List<TicketStub> ticketStubs = new List<TicketStub>();
            MySqlConnection dataBase = new MySqlConnection(connectionString);
            MySqlCommand firstDatabaseCommand = new MySqlCommand("SELECT * FROM `ost_ticket` WHERE `status` = 'open';",dataBase);
            /* TODO: Optimize this command,  Could probbably update the sql call to 
            "SELECT * FROM `ost_ticket__cdata` where `ticket_id` is" + currentListTicketstub.TicketId + ";" 
            Do this to avoid pulling down the entire damn table. */
            MySqlCommand SecondDatabaseCommand = new MySqlCommand("SELECT * FROM `ost_ticket__cdata`;",dataBase);
            try
            {
                dataBase.Open();
                MySqlDataReader ticketsReader = firstDatabaseCommand.ExecuteReader();
                while(ticketsReader.Read())
                {
                    TicketStub currentRow = new TicketStub();
                    currentRow.ticketTrueNumber = ticketsReader.GetInt32("ticket_id");
                    currentRow.ticketNumber = ticketsReader.GetInt32("number");
                    currentRow.creatorUserId = ticketsReader.GetInt32("user_id");
                    currentRow.ticketLastResponse = DateTime.Parse(ticketsReader.GetString("lastmessage"));
                    currentRow.ticketCreationDate = DateTime.Parse(ticketsReader.GetString("created"));
                    ticketStubs.Add(currentRow);       
                }
                ticketsReader.Close();
                ticketsReader = SecondDatabaseCommand.ExecuteReader();
                int totalTicketsProcessed = 0, ticketMatchesFound= 0;
                while (ticketsReader.Read())
                {
                    if (ticketMatchesFound >= ticketStubs.Count)
                       break;
                    if (ticketsReader.GetInt32("ticket_id") == ticketStubs[ticketMatchesFound].ticketTrueNumber)
                    {
                        ticketStubs[ticketMatchesFound].ticketCompany = ticketsReader.GetString("company");
                        ticketStubs[ticketMatchesFound].ticketSubject = ticketsReader.GetString("subject");
                        ticketStubs[ticketMatchesFound].ticketPriority = ticketsReader.GetInt32("priority_id");
                        totalTicketsProcessed++;
                        ticketMatchesFound++;
                    }                        
                    else
                        totalTicketsProcessed++;                    
                }
                ticketsReader.Close();
                                                    
            }
            catch (MySqlException)
            {
                throw;
            }
            finally
            {
                if (dataBase != null)
                    dataBase.Close();
                
            }
            return ticketStubs;
        }
        public List<TicketStub> PullClosedTickets(int maxResults)
        {
            return null;
        }
        public Ticket PullFullTicket(TicketStub stub)
        {
            return null;
        }
        public void ReplyToTicket(Message message)
        {
            //
        }
        public void CloseTicket(TicketStub stub)
        {
            //
        }
        public void CloseTicket(Ticket ticket)
        {
            //
        }
    }
}
