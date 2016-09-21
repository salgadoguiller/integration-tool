using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace ClassLibrary
{
    public class SendEmail
    {
         public void sendMail(string smtpUser,string smtpPassword,string smtpServer,string smtpPort,string from,string destination,string subject,string body,Integration integration)
         {
             try
             {
                MailMessage mail = new MailMessage(from, destination, subject, body);
                SmtpClient smtp = new SmtpClient();
                smtp.Host = smtpServer;
                smtp.Port = Convert.ToInt32(smtpPort);
                smtp.Credentials = new NetworkCredential(smtpUser, smtpPassword);

                smtp.EnableSsl = true;
                smtp.Send(mail);
             }
             catch (System.ArgumentException e)
             {               
                 string message = e.Message;
                 message = message.Replace("'", "");
                 string queryToLog2 = "insert into SystemLogs (Description,ErrorDate, IntegrationId) values('Class Send Mails: " + message + "','" + DateTime.Now + "'," + integration.integrationId + ")";
                 integration.insertSystemLog(queryToLog2);  
             }                        
         }
    }
}