using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTool.Models
{
    interface InterfaceDatabase
    {
        string connectionStringDatabase { get; set; }
        string ip { get; set; }
        string name { get; set; }
        string instance { get; set; }
        string username { get; set; }
        string password { get; set; }

        void openConexion();
        void closeConexion();
        string executeQuery(string query);
    }
}
