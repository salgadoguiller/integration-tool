using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ClassLibrary
{
    public class Curl
    {
        public void IntegrationWithCurl(string parameter, string locationCurl = @"C:\Users\cturcios\Desktop\IntegrationTool\Curl\curl.exe")
        {
            Process.Start(locationCurl, parameter);
        }
    }
}
