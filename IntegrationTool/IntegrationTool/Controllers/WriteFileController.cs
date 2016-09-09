﻿using System;
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

        /*public void writeFileByString(string headers, string resultQuery, string locationToSave)
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
        }*/

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
            StringBuilder csvContent = new StringBuilder();
            string header =headers.Replace("|", ",");
            string query=resultQuery.Replace("|",",");

            csvContent.AppendLine(header);
            csvContent.AppendLine(query);          
            string path = locationToSave+@"\"+nameIntegration + returnDatetimeNow() + ".csv";
            File.AppendAllText(path,csvContent.ToString());
        }

        public string returnDatetimeNow()
        {
            return DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
        }
    }
}