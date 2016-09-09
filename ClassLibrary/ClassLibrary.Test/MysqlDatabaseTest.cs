using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ClassLibrary;

namespace IntegrationTool.Tests
{
    [TestFixture]
    class MysqlDatabaseTest
    {
        [Test]
        public void mySqlDataBase_Connect_ReturnQueryResult()
        {
            MySqlDatabase mySql = new MySqlDatabase("","prueba", "localhost", "root", "","3306");
            string result = mySql.executeQuery("select * from prueba2");           
        }
    }
}
