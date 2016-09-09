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
         public void sendMail(string smtpUser,string smtpPassword,string smtpServer,int smtpPort,string from,string destination,string subject,string body)
         {                         
            MailMessage mail = new MailMessage(from,destination,subject,body);
        
            SmtpClient smtp = new SmtpClient();
            smtp.Host = smtpServer;
            smtp.Port = smtpPort;
            smtp.Credentials = new NetworkCredential(smtpUser, smtpPassword);

            smtp.EnableSsl = true;
            smtp.Send(mail);
         }
    }
}