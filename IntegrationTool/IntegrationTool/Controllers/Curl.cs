using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace IntegrationTool.Controllers
{
    public class Curl
    {
        public void IntegrationWithCurl(string parameter, string locationCurl = @"C:\Users\cturcios\Desktop\IntegrationTool\Curl\curl.exe")
        {
            Process.Start(locationCurl, parameter);
           
        }
    }
}