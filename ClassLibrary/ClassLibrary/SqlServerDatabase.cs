using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ClassLibrary
{
    public class SqlServerDatabase : InterfaceDatabase
    {
        private string ip;
        private string port;
        private string nameDataBase;
        private string serverInstance;
        private string username;
        private string password;

        private SqlConnection con = null;

        public SqlServerDatabase(string ip, string port, string nameDataBase, string serverInstance, string username, string password)
        {
            this.ip = ip;
            this.port = port;
            this.nameDataBase = nameDataBase;
            this.serverInstance = serverInstance;
            this.username = username;
            this.password = password;          
        }

        public void openConnection()
        {
            string conectionString = "Data Source=" + this.ip + ";" +
                                    "Initial Catalog=" + this.nameDataBase + ";Integrated Security=true;";
            this.con = new SqlConnection(conectionString);
            this.con.Open();
        }

        public void closeConnection()
        {
            if (con != null)
                con.Close();

            con = null;
        }

        public string executeQuery(string query)
        {
            
            //openConnection();

            SqlCommand queryCommand = new SqlCommand(query, con);
            SqlDataReader reader = queryCommand.ExecuteReader();
            
            closeConnection();
        

            if (reader.Read())
                return reader.GetString(0);
            else
                throw new Exception();

           
        }
    }
}
