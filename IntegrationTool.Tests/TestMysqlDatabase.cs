using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationTool.Models;
using NUnit.Framework;

namespace IntegrationTool.Tests
{
    [TestFixture]
    class TestMysqlDatabase
    {
        [Test]
        public void pruebaDeConexion()
        {
            MySqlDatabase patito = new MySqlDatabase("","prueba", "localhost", "root", "","3306");
            string gg =patito.executeQuery("select * from prueba2");           
        }
    }
}
