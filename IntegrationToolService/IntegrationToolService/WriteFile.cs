using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationToolService
{
    class WriteFile
    {
        public void writeFileByString2(string headers, string resultQuery, string locationToSave, string nameIntegration)
        {
            string path = locationToSave + @"\" + nameIntegration + "-" + returnDatetimeNow() + ".txt";
            FileStream fs = new FileStream(path, FileMode.Append);
            using (StreamWriter file = new StreamWriter(fs, Encoding.UTF8))
            {
                file.Write(headers);
                file.WriteLine();
                file.Write(resultQuery);
            }
        }

        public void writeIntegrationinExcel(string headers, string resultQuery, string locationToSave,
            string nameIntegration)
        {
            StringBuilder csvContent = new StringBuilder();
            string header = headers.Replace("|", ",");
            string query = resultQuery.Replace("|", ",");

            csvContent.AppendLine(header);
            csvContent.AppendLine(query);
            string path = locationToSave + @"\" + nameIntegration + returnDatetimeNow() + ".csv";
            File.AppendAllText(path, csvContent.ToString());
        }

        public string returnDatetimeNow()
        {
            return DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
        }
    }
}


















