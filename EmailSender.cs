using System;
using System.Net.Mail;
using System.Net;
namespace dotNet_ass1
{
    public class EmailSender
    {
        public void sendEmail(string from, string to, EmailBody emailBody, double balance)
        {
            using (SmtpClient smtpClient = new SmtpClient())
            {
                var basicCredential = new NetworkCredential("xuzhuang9897@gmail.com", "Wacdzx666");
                using (MailMessage message = new MailMessage())
                {
                    MailAddress fromAddress = new MailAddress(from);

                    smtpClient.EnableSsl = true;
                    smtpClient.Port = 587;
                    smtpClient.Host = "smtp.gmail.com";
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = basicCredential;

                    message.From = fromAddress;
                    message.Subject = "Your new KAZ bank account detail";
                    // Set IsBodyHtml to true means you can send HTML email.
                    message.IsBodyHtml = true;
                    message.Body = $"<h3>Below is your new account detail</h3>" +
                        $"\n<p>Account number: {emailBody.userAccNum}</p> " +
                        $"\n<p>First name: {emailBody.userFirstName}</p>" +
                        $"\n<p>Last name: {emailBody.userLastName}</p>" +
                        $"\n<p>Address: {emailBody.userAddress}</p>" +
                        $"\n<p>Phone: {emailBody.userPhone}</p>";
                    message.To.Add(to);

                    try
                    {
                        Console.WriteLine("                  Please wait for the email to be sent...");
                        smtpClient.Send(message);
                    }
                    catch (Exception ex)
                    {
                        //Error, could not send the message
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}
