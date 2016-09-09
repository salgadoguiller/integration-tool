using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace IntegrationToolService
{
    class WriteFile
    {
        public void writeFileinFlatFile()
        {
            WriteFileController writeFileController = new WriteFileController();
            writeFileController.writeFileinFlatFile("1", "dd", "df", "dg");

        }

        public void writeFileinCSVFile()
        {
            WriteFileController writeFileController = new WriteFileController();
            writeFileController.writeIntegrationinExcel("dfsd", "asdf", "", "sdf");
        }
    }
}
