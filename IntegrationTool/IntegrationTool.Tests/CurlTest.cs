using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationTool.Controllers;
using NUnit.Framework;


namespace IntegrationTool.Tests
{
    [TestFixture]
    class CurlTest
    {
        [Test]
        public void IntegrationWithCurl()
        {
            Curl curl= new Curl();
            curl.IntegrationWithCurl("curl --help");
             
        }
    }
}
