﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class DataBaseFactory
    {
        public InterfaceDatabase createDataBase(string ip, string port, string nameDataBase, string serverInstance, string username, string password, string engine)
        {
            if (engine == "SqlServer")
                return new SqlServerDatabase(ip, port, nameDataBase, serverInstance, username, password);
            else
                return new MySqlDatabase(ip, nameDataBase, serverInstance, username, password,port);
        }
    }
}