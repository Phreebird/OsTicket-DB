using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace OsTicketDBNav
{
    public class Database
    {
        private string connectionString, dbName;
        public Database(String dbServer, String dbName, String dbUser, String dbPassword)
        {
            this.connectionString = "Server=" + dbServer + ";Database=" + dbName + ";Uid=" + dbUser + ";Pwd=" + dbPassword + ";" + "Convert Zero Datetime=True";
            this.dbName = dbName;
        }
        public List<TicketStub> PullOpenTicketStubs()
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
        public List<TicketStub> PullClosedTicketStubs(int maxResults)
        {
            List<TicketStub> ticketStubs = new List<TicketStub>(maxResults);
            MySqlConnection dataBase = new MySqlConnection(connectionString);
            MySqlCommand firstDatabaseCommand = new MySqlCommand("SELECT * FROM `ost_ticket` WHERE `status` = 'closed' LIMIT " + maxResults + "", dataBase);
            /* TODO: Optimize this command,  Could probbably update the sql call to 
            "SELECT * FROM `ost_ticket__cdata` where `ticket_id` is" + currentListTicketstub.TicketId + ";" 
            Do this to avoid pulling down the entire damn table. */
            MySqlCommand SecondDatabaseCommand = new MySqlCommand("SELECT * FROM `ost_ticket__cdata`;", dataBase);
            try
            {
                dataBase.Open();
                MySqlDataReader ticketsReader = firstDatabaseCommand.ExecuteReader();
                while (ticketsReader.Read())
                {
                    TicketStub currentRow = new TicketStub();
                    currentRow.ticketTrueNumber = ticketsReader.GetInt32("ticket_id");
                    currentRow.ticketNumber = ticketsReader.GetInt32("number");
                    currentRow.creatorUserId = ticketsReader.GetInt32("user_id");
                    currentRow.ticketLastResponse = DateTime.Parse(ticketsReader.GetString("lastmessage"));
                    currentRow.ticketCreationDate = DateTime.Parse(ticketsReader.GetString("created"));
                    currentRow.isOpen = false;
                    ticketStubs.Add(currentRow);
                }
                ticketsReader.Close();
                ticketsReader = SecondDatabaseCommand.ExecuteReader();
                int totalTicketsProcessed = 0, ticketMatchesFound = 0;
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
        public Ticket PullFullTicket(TicketStub stub)
        {
            MySqlConnection dataBase = new MySqlConnection(connectionString);
            MySqlCommand pullThreadsCommand = new MySqlCommand("SELECT * FROM `ost_ticket_thread` WHERE `ticket_id` = " + stub.ticketTrueNumber + ";", dataBase);
            Ticket newTicket = new Ticket(stub);
            try
            {
                dataBase.Open();
                MySqlDataReader reader = pullThreadsCommand.ExecuteReader();
                newTicket.ticketResponses = new List<Message>();
                while (reader.Read())
                {
                    Message currentMessage = new Message();
                    currentMessage.responseNumber = reader.GetInt32("id");
                    currentMessage.threadType = reader.GetChar("thread_type");
                    currentMessage.posterName = reader.GetString("poster");
                    currentMessage.messageTitle = reader.GetString("title");
                    currentMessage.messageData = reader.GetString("body");
                    currentMessage.timeRecieved = DateTime.Parse(reader.GetString("created"));
                    newTicket.ticketResponses.Add(currentMessage);
                }
                reader.Close();
            }
            catch (Exception) {
                throw;
            }
            finally { 
                dataBase.Close();
            }
            return newTicket;
        }
        public void ReplyToTicket(Ticket ticketToRespondTo, Message messageToReplyWith)
        {
            //
        }
        public void CloseTicket(TicketStub stub)
        {
            MySqlConnection database = new MySqlConnection(connectionString);
            int ticketNumberToCLose = stub.ticketTrueNumber;
            try
            {
                MySqlCommand closeTicketCommand = new MySqlCommand("UPDATE `ost_ticket` SET `status`=\"closed\" WHERE `ticket_id`=" + ticketNumberToCLose + ";", database);
                MySqlCommand addTimeClosedCommand = new MySqlCommand("UPDATE `ost_ticket` SET `closed`=\"" + DateTime.Now.ToString("yyyy-MM-dd h:mm:tt") + "\" WHERE `ticket_id`=" + ticketNumberToCLose + ";", database);                
                database.Open();
                if (closeTicketCommand.ExecuteNonQuery() == 0)
                    throw new Exception("Zero rows affected.");
                if (addTimeClosedCommand.ExecuteNonQuery() == 0)
                    throw new Exception("Zero rows affected.");
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if(database != null)
                    database.Close();
            }
        }
    }
}
