using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ClassLibrary
{
    public class MySqlDatabase : InterfaceDatabase
    {
        private string Ip;
        private string nameDatabase;
        private string serverInstance;
        private string username;
        private string password;
        private string port;
        private MySqlConnection connection;


        public MySqlDatabase(string ip, string nameDatabase, string serverInstance, string username, string password, string port)
        {
            this.Ip = ip;
            this.nameDatabase = nameDatabase;
            this.serverInstance = serverInstance;
            this.username = username;
            this.password = password;
            this.port = port;

            connectionStringDatabase();
        }

        private void connectionStringDatabase()
        {
            MySqlConnectionStringBuilder instanceDatabase = new MySqlConnectionStringBuilder();
            instanceDatabase.Server = this.serverInstance;
            instanceDatabase.UserID = this.username;
            instanceDatabase.Password = this.password;
            instanceDatabase.Database = this.nameDatabase;
            instanceDatabase.Port = Convert.ToUInt32(this.port);

            connectionDatabase(instanceDatabase.ToString());
        }

        private void connectionDatabase(string instanceDatabase)
        {
            connection = new MySqlConnection(instanceDatabase);
        }

        public void openConnection()
        {
            try
            {
                connection.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }           
        }

        public void closeConnection()
        {
            try
            {
                connection.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                Console.WriteLine(e.Message);
            }              
        }

        public string executeQuery(string query)
        {
            string responseQuery = "";

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = query;
            //openConnection();
            try
            {
                command.ExecuteNonQuery();
                MySqlDataReader returnQuery = command.ExecuteReader();

                while (returnQuery.Read())
                {
                    string response = returnQuery.GetString(0);
                    responseQuery += response + "%";
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
                  
            //closeConnection();
            return responseQuery;
        }  
    }
}
