using System;
using System.IO;
namespace dotNet_ass1
{
    //display create account page
    public class CreateAccount
    {
        private bool error;
        private string firstName, lastName, userAddress, emailAdd;
        private int phoneNum;
        private int feedbackLeft, feedbackTop;

        //default email sender address
        private string emailSenderAddress = "xuzhuang9897@gmail.com";
        public void NewAccScreen()
        {
            //do while loop to keep displaying the page if user wants to re-enter
            do
            {
                try
                {
                    error = false;
                    Console.Clear();
                    Console.WriteLine("\t ------------------------------------------------------------- ");
                    Console.WriteLine("\t|                      Create A New Account                   |");
                    Console.WriteLine("\t =============================================================");
                    Console.WriteLine("\t|                     Enter the Field Below                   |");
                    Console.WriteLine("\t|                                                             |");
                    Console.Write("\t| First Name: ");

                    //record cursor position for entering firstname
                    int firstNameLeft = Console.CursorLeft;
                    int firstNameTop = Console.CursorTop;
                    Console.Write("                                                |\n");
                    Console.Write("\t| Last Name: ");
                    int lastNameLeft = Console.CursorLeft;
                    int lastNameTop = Console.CursorTop;
                    Console.Write("                                                 |\n");
                    Console.Write("\t| Address: ");
                    int addressLeft = Console.CursorLeft;
                    int addressTop = Console.CursorTop;
                    Console.Write("                                                   |\n");
                    Console.Write("\t| Phone: ");
                    int phoneLeft = Console.CursorLeft;
                    int phoneTop = Console.CursorTop;
                    Console.Write("                                                     |\n");
                    Console.Write("\t| Email: ");
                    int emailLeft = Console.CursorLeft;
                    int emailTop = Console.CursorTop;
                    Console.Write("                                                     |\n");
                    Console.WriteLine("\t|                                                             |");
                    Console.WriteLine("\t ------------------------------------------------------------- ");
                    this.feedbackLeft = Console.CursorLeft;
                    this.feedbackTop = Console.CursorTop;

                    //set the cursor position to firstname enter position
                    Console.SetCursorPosition(firstNameLeft, firstNameTop);
                    this.firstName = Console.ReadLine();
                    Console.SetCursorPosition(lastNameLeft, lastNameTop);
                    this.lastName = Console.ReadLine();
                    Console.SetCursorPosition(addressLeft, addressTop);
                    this.userAddress = Console.ReadLine();
                    Console.SetCursorPosition(phoneLeft, phoneTop);
                    string tempInput = Console.ReadLine();
                    this.phoneNum = Convert.ToInt32(tempInput);

                    //check if the input is within 10 integer
                    if (tempInput.Length > 10)
                    {
                        throw new Exception("Please enter a valid phone number");
                    }
                    
                    
                    Console.SetCursorPosition(emailLeft, emailTop);
                    this.emailAdd = Console.ReadLine();

                    //check if email entered contains @
                    if (!this.emailAdd.Contains("@"))
                    {
                        throw new Exception("Please enter a valid email address");
                    }

                    //check if email entered contains specific domain name
                    if (!this.emailAdd.Contains("gmail.com") && !this.emailAdd.Contains("outlook.com") && !this.emailAdd.Contains("uts.edu.au"))
                    {
                        throw new Exception("Please enter a valid email address");
                    }
                    Console.SetCursorPosition(this.feedbackLeft, this.feedbackTop);

                    //handle user input for confirm y/n
                    string confirm = "";

                    //loop until user enter either y or n
                    while (confirm != "y" && confirm != "n")
                    {
                        Console.Write("\t\t Is the information correct (y/n)? ");
                        confirm = Console.ReadLine();
                    }

                    //if n, throw empty exception and let user re-enter details
                    if (confirm == "n")
                    {
                        throw new Exception("");
                    }

                    //Go to the file database to generate a new uniq account number
                    int newAccNum = genNewAccNum();

                    //generate a struct for email body
                    var emailBody = new EmailBody(this.firstName, this.lastName, this.userAddress, this.emailAdd, newAccNum, this.phoneNum);

                    //send the email to the user
                    EmailSender newEmail = new EmailSender();
                    newEmail.sendEmail(this.emailSenderAddress, this.emailAdd, emailBody, 0, true);

                    //Save the user detail to a file
                    saveAccToDB(emailBody);

                    Console.WriteLine("\t\t Account detail is sent to the provided email address");
                    Console.WriteLine("\t\t Your new Account number is: " + newAccNum);
                    Console.WriteLine("\t\t Press any key to go to the menu..");
                    
                    Console.ReadKey();


                }
                catch (Exception e)
                {
                    //set error to true so that loop would continue to loop
                    error = true;
                    Console.SetCursorPosition(this.feedbackLeft, this.feedbackTop);
                    Console.WriteLine("\t\t " + e.Message);
                    Console.WriteLine("\t\t Press any key to re-enter details..");
                    Console.ReadKey();
                }
            } while (error);
        }
        private int genNewAccNum()
        {
            //store all lines in to array
            string[] allAcc = File.ReadAllLines("accDB.txt");

            //generate a new uniq number, 100000 as base number, then add new number
            //if 100000, length = 1, next number would be 100001
            int newAccNum = 100000 + allAcc.Length;
            return newAccNum;
        }
        private void saveAccToDB(EmailBody emailBody)
        {
            //Write all the user details into a file
            File.WriteAllText($"{emailBody.userAccNum}.txt", Convert.ToString(emailBody.userAccNum));
            File.AppendAllText($"{emailBody.userAccNum}.txt", $"\n{0}");
            File.AppendAllText($"{emailBody.userAccNum}.txt", $"\n{emailBody.userFirstName}");
            File.AppendAllText($"{emailBody.userAccNum}.txt", $"\n{emailBody.userLastName}");
            File.AppendAllText($"{emailBody.userAccNum}.txt", $"\n{emailBody.userAddress}");
            File.AppendAllText($"{emailBody.userAccNum}.txt", $"\n{emailBody.userPhone}");
            File.AppendAllText($"{emailBody.userAccNum}.txt", $"\n{emailBody.userEmail}");

            //Append the new acc number to the "account databse"
            string appendableNum = Convert.ToString(emailBody.userAccNum);

            //check if the databse is empty and determine if it should escape a line
            //if database is empty, append acc num with out adding a line on top
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
