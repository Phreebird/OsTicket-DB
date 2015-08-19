using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace OsTicketDBNav
{
    public class DBNav
    {
        private string connectionString;
        public DBNav(String dbServer, String dbName, String dbUser, String dbPassword)
        {
            this.connectionString = "Server=" + dbServer + ";Database=" + dbName + ";Uid=" + dbUser + ";Pwd=" + dbPassword + ";" + "Convert Zero Datetime=True";
        }
        public DataSet PullTickets()
        {
            MySqlConnection dataBase = new MySqlConnection(connectionString);
            MySqlCommand databaseCommand = new MySqlCommand();
            try
            {
                dataBase.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM `ost_ticket` WHERE `status` = 'open';", dataBase);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataBase.Close();
                return ds;          
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
