using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class WriteFileController
    {
        public string writeFileinFlatFile(string resultQuery, string locationToSave, string nameIntegration)
        {
            string nameFile = nameIntegration+"-"+returnDatetimeNow()+".txt";

            string path = locationToSave + "/" + nameFile;

            try
            {
                FileStream fs = new FileStream(path, FileMode.Append);
                using (StreamWriter file = new StreamWriter(fs, Encoding.UTF8))
                {
                    string[] resultParse = resultQuery.Split('%');

                    for (int i = 0; i < resultParse.Length; i++)
                    {
                        file.WriteLine(resultParse[i]);
                    }
                }
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message );
            }
        
            return path+"|"+nameFile;
        }

        public string writeIntegrationinExcel(string resultQuery, string locationToSave, string nameIntegration)
        {
            StringBuilder csvContent = new StringBuilder();           
            string query = resultQuery.Replace("%", ",");

            //csvContent.AppendLine(header);
            csvContent.AppendLine(query);
            string path = locationToSave + @"\" + nameIntegration + returnDatetimeNow() + ".csv";
            File.AppendAllText(path, csvContent.ToString());

            return path;
        }

        private string returnDatetimeNow()
        {
            return DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
        }
    }
}
