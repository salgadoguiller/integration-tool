using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using IntegrationTool.Models;

namespace IntegrationTool.Tests
{
    [TestFixture]
    class DataBaseFactoryTest
    {
        [TestCase("172.20.33.13", "", "IntegrationTool", "", "", "", "SQLServer", "SELECT 'abc'")]
        [TestCase("172.20.33.13", "", "IntegrationTool", "", "", "", "SQLServer", "SELECT 'abc'")]
        public void sqlServerDataBase_ConnectWithFactoryMethod_ReturnQueryResult(string ip, string port, string nameDataBase, string serverInstance, string username, string password, string engine, string query)
        {
            DataBaseFactory factory = new DataBaseFactory();
            InterfaceDatabase dataBase = factory.createDataBase(ip, port, nameDataBase, serverInstance, username, password, engine);
            dataBase.openConnection();
            string result = dataBase.executeQuery(query);
            dataBase.closeConnection();

            Console.Write(result);
        }
    }
}
