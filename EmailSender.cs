using System;
using System.Net.Mail;
using System.Net;
namespace dotNet_ass1
{
    public class EmailSender
    {
        public void sendEmail(string from, string to)
        {
            using (SmtpClient smtpClient = new SmtpClient())
            {
                var basicCredential = new NetworkCredential("xuzhuang9897@gmail.com", "Wacdzx666");
                using (MailMessage message = new MailMessage())
                {
                    MailAddress fromAddress = new MailAddress("xuzhuang9897@gmail.com");

                    smtpClient.EnableSsl = true;
                    smtpClient.Port = 587;
                    smtpClient.Host = "smtp.gmail.com";
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = basicCredential;

                    message.From = fromAddress;
                    message.Subject = "your subject";
                    // Set IsBodyHtml to true means you can send HTML email.
                    message.IsBodyHtml = true;
                    message.Body = "<h1>your message body</h1>";
                    message.To.Add("kevin7441@gmail.com");

                    try
                    {
                        smtpClient.Send(message);
                    }
                    catch (Exception ex)
                    {
                        //Error, could not send the message
                        Console.Write(ex.Message);
                    }
                }
            }
        }
    }
}
