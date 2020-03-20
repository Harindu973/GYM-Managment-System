using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace Home
{
    class Email
    {
        public Email(string subject,string MBody)
        {
             try
             {

                 MailMessage mail = new MailMessage();
                 SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                 mail.From = new MailAddress("focusoevuredev@gmail.com");
                 mail.To.Add("harindulakshankob@gmail.com");
                

                 mail.Subject = subject;


                 mail.Body = MBody;
                 mail.Attachments.Add(new Attachment("D:/Images/DataGridView.png"));

                SmtpServer.Port = 587;
                 SmtpServer.Credentials = new System.Net.NetworkCredential("focusoevuredev@gmail.com", "tfo12345!");
                 SmtpServer.EnableSsl = true;

                 SmtpServer.Send(mail);

                
             }
             catch (Exception)
             {
                 // MessageBox.Show(ex.ToString());
             } 





            
            





        }


    }
}
