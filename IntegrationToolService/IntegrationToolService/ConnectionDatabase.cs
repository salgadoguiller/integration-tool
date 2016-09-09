using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace IntegrationToolService
{
    class ConnectionDatabase
    {
       DataBaseFactory dataBaseFactory = new DataBaseFactory();


        public void instanceMethod()
        {
            InterfaceDatabase   d=  dataBaseFactory.createDataBase(null, null, null, null, null, null, null);
        }
    }
}
