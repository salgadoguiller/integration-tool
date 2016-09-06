using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;
using DocumentFormat.OpenXml;
using ClosedXML.Excel;

namespace IntegrationTool.Controllers
{
    public class WriteFileController
    {
       /* public void writeFileByArray(string[] headers,string[] resultQuery ,string locationToSave)
        {
            FileStream fs = new FileStream(locationToSave,FileMode.OpenOrCreate);

            using (StreamWriter file = new StreamWriter(fs, Encoding.UTF8))
            {
                for(int i=0; i<headers.Length;i++)
                {
                    file.Write(headers[i]+"|");
                }

                file.WriteLine();

                for (int i = 0; i < resultQuery.Length; i++)
                {
                    file.Write(headers[i] + "|");
                }                                       
            }
        }*/

        public void writeFileByString(string headers, string resultQuery, string locationToSave)
        {
            FileStream fs = null;

            if (File.Exists(locationToSave))
            {
                fs = new FileStream(locationToSave, FileMode.Append);

                using (StreamWriter file = new StreamWriter(fs, Encoding.UTF8))
                {
                    file.WriteLine();
                    file.Write(resultQuery);
                }
            }

            else
            {
                fs = new FileStream(locationToSave, FileMode.Append);

                using (StreamWriter file = new StreamWriter(fs, Encoding.UTF8))
                {                  
                    file.Write(headers);
                    file.WriteLine();
                    file.Write(resultQuery);
                }
            }
        }

        public void writeFileByString2(string headers, string resultQuery, string locationToSave,string nameIntegration)
        {           
            string path = locationToSave + @"\"+nameIntegration+"-"+returnDatetimeNow()+".txt";
            FileStream fs = new FileStream(path, FileMode.Append);
            using (StreamWriter file = new StreamWriter(fs, Encoding.UTF8))
            {
                file.Write(headers);
                file.WriteLine();
                file.Write(resultQuery);
            }            
        }

        public void writeIntegrationinExcel(string headers,string resultQuery,string locationToSave,string nameIntegration)
        {
            string[] alphabet = { "A","B","C","D","E","F","G","H","I","J","k","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"};                   
            string [] header = headers.Split('|');
            string[] query = resultQuery.Split('|');

            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add(nameIntegration + "-Integrations");
           
            for (int i = 0; i < header.Length; i++)
            {              
                worksheet.Cell(alphabet[i]+"1").Value = header[i];
                worksheet.Cell(alphabet[i] + "2").Value = query[i];              
            }
           
            worksheet.Columns().AdjustToContents();          
            string path = locationToSave+@"\"+nameIntegration + returnDatetimeNow() + ".xlsx";
            workbook.SaveAs(path);       
        }

        public string returnDatetimeNow()
        {
            return DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
        }
    }
}