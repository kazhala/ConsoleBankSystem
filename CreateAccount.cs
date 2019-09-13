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
                    feedbackLeft = Console.CursorLeft;
                    feedbackTop = Console.CursorTop;
                    Console.SetCursorPosition(firstNameLeft, firstNameTop);
                    this.firstName = Console.ReadLine();
                    Console.SetCursorPosition(lastNameLeft, lastNameTop);
                    this.lastName = Console.ReadLine();
                    Console.SetCursorPosition(addressLeft, addressTop);
                    this.userAddress = Console.ReadLine();
                    Console.SetCursorPosition(phoneLeft, phoneTop);
                    string tempInput = Console.ReadLine();
                    if (tempInput.Length > 10)
                    {
                        throw new Exception("Please enter a valid phone number");
                    }
                    phoneNum = Convert.ToInt32(tempInput);
                    
                    Console.SetCursorPosition(emailLeft, emailTop);
                    emailAdd = Console.ReadLine();
                    if (!emailAdd.Contains("@"))
                    {
                        throw new Exception("Please enter a valid email address");
                    }
                    //Console.WriteLine(emailAdd.Contains("gmail.com"));
                    if (!emailAdd.Contains("gmail.com") && !emailAdd.Contains("outlook.com") && !emailAdd.Contains("uts.edu.au"))
                    {
                        throw new Exception("Please enter a valid email address");
                    }
                    Console.SetCursorPosition(feedbackLeft, feedbackTop);
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

                    //send the email here
                    EmailSender newEmail = new EmailSender();
                    newEmail.sendEmail("xuzhuang9897@gmail.com", "kevin7441@gmail.com");

                    Console.WriteLine("                  Account detail is sent to the provided email address");
                    

                    Console.ReadKey();


                }
                catch (Exception e)
                {
                    error = true;
                    Console.SetCursorPosition(feedbackLeft, feedbackTop);
                    Console.WriteLine("                 " + e.Message);
                    Console.WriteLine("                 Press any key to re-enter details..");
                    Console.ReadKey();
                }
            } while (error);
        }
        private int genNewAccNum()
        {
            FileStream accDB = new FileStream("accDB.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            string[] allAcc = File.ReadAllLines("accDB.txt");
            int newAccNum = 100000 + allAcc.Length;
            string appendableNum = Convert.ToString(newAccNum);
            File.AppendAllText("accDB.txt", "\n" + appendableNum);
            accDB.Close();
            return newAccNum;
        }
    }
}
