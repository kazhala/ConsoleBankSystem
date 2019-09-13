using System;
using System.IO;
namespace dotNet_ass1
{
    public class CreateAccount
    {
        private bool error;
        private string firstName, lastName, userAddress, emailAdd;
        private int phoneNum;
        private int feedbackLeft, feedbackTop;
        private string emailSenderAddress = "xuzhuang9897@gmail.com";
        public void NewAccScreen()
        {
            do
            {
                try
                {
                    error = false;
                    Console.Clear();
                    Console.WriteLine("         ------------------------------------------------------------- ");
                    Console.WriteLine("        |                      Create A New Account                   |");
                    Console.WriteLine("         =============================================================");
                    Console.WriteLine("        |                     Enter the Field Below                   |");
                    Console.WriteLine("        |                                                             |");
                    Console.Write("        | First Name: ");
                    int firstNameLeft = Console.CursorLeft;
                    int firstNameTop = Console.CursorTop;
                    Console.Write("                                                |\n");
                    Console.Write("        | Last Name: ");
                    int lastNameLeft = Console.CursorLeft;
                    int lastNameTop = Console.CursorTop;
                    Console.Write("                                                 |\n");
                    Console.Write("        | Address: ");
                    int addressLeft = Console.CursorLeft;
                    int addressTop = Console.CursorTop;
                    Console.Write("                                                   |\n");
                    Console.Write("        | Phone: ");
                    int phoneLeft = Console.CursorLeft;
                    int phoneTop = Console.CursorTop;
                    Console.Write("                                                     |\n");
                    Console.Write("        | Email: ");
                    int emailLeft = Console.CursorLeft;
                    int emailTop = Console.CursorTop;
                    Console.Write("                                                     |\n");
                    Console.WriteLine("        |                                                             |");
                    Console.WriteLine("         ------------------------------------------------------------- ");
                    this.feedbackLeft = Console.CursorLeft;
                    this.feedbackTop = Console.CursorTop;
                    Console.SetCursorPosition(firstNameLeft, firstNameTop);
                    this.firstName = Console.ReadLine();
                    Console.SetCursorPosition(lastNameLeft, lastNameTop);
                    this.lastName = Console.ReadLine();
                    Console.SetCursorPosition(addressLeft, addressTop);
                    this.userAddress = Console.ReadLine();
                    Console.SetCursorPosition(phoneLeft, phoneTop);
                    string tempInput = Console.ReadLine();
                    this.phoneNum = Convert.ToInt32(tempInput);
                    if (tempInput.Length > 10)
                    {
                        throw new Exception("Please enter a valid phone number");
                    }
                    
                    
                    Console.SetCursorPosition(emailLeft, emailTop);
                    this.emailAdd = Console.ReadLine();
                    if (!this.emailAdd.Contains("@"))
                    {
                        throw new Exception("Please enter a valid email address");
                    }
                    //Console.WriteLine(emailAdd.Contains("gmail.com"));
                    if (!this.emailAdd.Contains("gmail.com") && !this.emailAdd.Contains("outlook.com") && !this.emailAdd.Contains("uts.edu.au"))
                    {
                        throw new Exception("Please enter a valid email address");
                    }
                    Console.SetCursorPosition(this.feedbackLeft, this.feedbackTop);
                    string confirm = "";
                    while (confirm != "y" && confirm != "n")
                    {
                        Console.Write("                  Is the information correct (y/n)? ");
                        confirm = Console.ReadLine();
                    }
                    if (confirm == "n")
                    {
                        throw new Exception("");
                    }
                    //Get the account number
                    int newAccNum = genNewAccNum();
                    var emailBody = new EmailBody(this.firstName, this.lastName, this.userAddress, this.emailAdd, newAccNum, this.phoneNum);
                    //send the email here
                    EmailSender newEmail = new EmailSender();
                    newEmail.sendEmail(this.emailSenderAddress, this.emailAdd, emailBody, 0);
                    saveAccToDB(emailBody);

                    Console.WriteLine("                  Account detail is sent to the provided email address");
                    Console.WriteLine("                  Your new Account number is: " + newAccNum);
                    Console.WriteLine("                  Press any key to go to the menu..");
                    
                    Console.ReadKey();


                }
                catch (Exception e)
                {
                    error = true;
                    Console.SetCursorPosition(this.feedbackLeft, this.feedbackTop);
                    Console.WriteLine("                 " + e.Message);
                    Console.WriteLine("                 Press any key to re-enter details..");
                    Console.ReadKey();
                }
            } while (error);
        }
        private int genNewAccNum()
        {
            //FileStream accDB = new FileStream("accDB.txt", FileMode.OpenOrCreate, FileAccess.Read);
            string[] allAcc = File.ReadAllLines("accDB.txt");
            int newAccNum = 100000 + allAcc.Length;
            //accDB.Close();
            return newAccNum;
        }
        private void saveAccToDB(EmailBody emailBody)
        {
            //FileStream newAccFile = new FileStream($"{emailBody.userAccNum}.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            File.WriteAllText($"{emailBody.userAccNum}.txt", Convert.ToString(emailBody.userAccNum));
            File.AppendAllText($"{emailBody.userAccNum}.txt", $"\n{0}");
            File.AppendAllText($"{emailBody.userAccNum}.txt", $"\n{emailBody.userFirstName}");
            File.AppendAllText($"{emailBody.userAccNum}.txt", $"\n{emailBody.userLastName}");
            File.AppendAllText($"{emailBody.userAccNum}.txt", $"\n{emailBody.userAddress}");
            File.AppendAllText($"{emailBody.userAccNum}.txt", $"\n{emailBody.userPhone}");
            File.AppendAllText($"{emailBody.userAccNum}.txt", $"\n{emailBody.userEmail}");
            //newAccFile.Close();
            string appendableNum = Convert.ToString(emailBody.userAccNum);
            if (File.ReadAllLines("accDB.txt").Length == 0)
            {
                File.AppendAllText("accDB.txt", appendableNum);
            } else
            {
                File.AppendAllText("accDB.txt", "\n" + appendableNum);
            }
        }
    }
}
