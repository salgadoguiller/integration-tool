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
    class SystemConfigurationDBTest
    {
        [TestCase("ADDomain", "ADPath")]
        public void sqlServerDataBase_Connect_ReturnQueryResult(string domain, string path)
        {
            SystemConfiguration systemConfigurationModel = new SystemConfiguration();
            systemConfigurationModel.setActiveDirectory(domain, path);
        }
    }
}
