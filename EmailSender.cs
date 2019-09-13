using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Net;
namespace dotNet_ass1
{
    public class EmailSender
    {
        public void sendEmail(string from, string to)
        {
            MailMessage mail = new MailMessage(from, to);
            mail.Subject = "test";
            mail.Body = "test";

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;

            smtp.Credentials = new NetworkCredential(
                "xuzhuang9897@gmail.com", "Wacdzx666");
            smtp.EnableSsl = true;
            Console.WriteLine("Sending email...");
            try
            {
                smtp.Send(mail);
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
        }
    }
}
