﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTool.Models
{
    interface InterfaceDatabase
    {      
        void openConnection();
        void closeConnection();
        string executeQuery(string query);
    }
}
