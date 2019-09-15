using System;
using System.IO;
namespace dotNet_ass1
{
    //display statement
    public class Statement
    {
        private bool error;
        private int accNum;
        private int feedbackLeft, feedbackTop;

        //default sender email
        private string emailSenderAddress = "xuzhuang9897@gmail.com";
        public void StatementScreen()
        {
            ErrorHandler errorHandler = new ErrorHandler();
            CheckDBacc checkDBacc = new CheckDBacc();

            //do while loop incase user wants to re enter
            do
            {
                try
                {
                    this.error = false;
                    Console.Clear();
                    Console.WriteLine("\t ------------------------------------------------------------- ");
                    Console.WriteLine("\t|                           Statement                         |");
                    Console.WriteLine("\t =============================================================");
                    Console.WriteLine("\t|                 Enter the Account number below              |");
                    Console.WriteLine("\t|                                                             |");
                    Console.Write("\t| Account number: ");

                    //record cursor position
                    int numberLeft = Console.CursorLeft;
                    int numberTop = Console.CursorTop;
                    Console.Write("                                            |\n");
                    Console.WriteLine("\t|                                                             |");
                    Console.WriteLine("\t ------------------------------------------------------------- ");
                    this.feedbackLeft = Console.CursorLeft;
                    this.feedbackTop = Console.CursorTop;

                    //set cursor position
                    Console.SetCursorPosition(numberLeft, numberTop);

                    string tempInput = Console.ReadLine();
                    //Console.WriteLine(tempInput);
                    this.accNum = Convert.ToInt32(tempInput);

                    //check for input digit less than 10
                    //check for input 0 for accDB use 0 as placeholder
                    if (tempInput.Length > 10 || this.accNum == 0)
                    {
                        throw new Exception("Invalid account number");
                    }
                    Console.SetCursorPosition(this.feedbackLeft, this.feedbackTop);
                    if (!checkDBacc.checkExist(this.accNum))
                    {
                        throw new Exception("Account not found");
                    }
                    else if (checkDBacc.checkExist(this.accNum))
                    {
                        Console.WriteLine("\t\t Account found, statement is displayed below.");
                        Console.WriteLine("");

                        //display statement
                        DisplayFound(this.accNum);
                    }

                    
                }
                catch (Exception e)
                {
                    Console.SetCursorPosition(this.feedbackLeft, this.feedbackTop);
                    Console.WriteLine("\t\t " + e.Message);

                    //set error based on userInput
                    this.error = errorHandler.CheckUserInput();
                    
                }
            } while (this.error);
        }


        //display statement
        private void DisplayFound(int accnumber)
        {
            DisplayDetail displayDetail = new DisplayDetail();

            //store all the detail into array
            string[] accoutDetail = File.ReadAllLines($"{accnumber}.txt");
            Console.WriteLine("\t ------------------------------------------------------------- ");
            Console.WriteLine("\t|                        Account Details                      |");
            Console.WriteLine("\t =============================================================");
            Console.WriteLine("\t\t\b\b\bAccount Statement");
            Console.WriteLine("");

            //display detail
            displayDetail.UserDetails(accoutDetail);

            //display recent transaction below
            //based on number of transcations, switch display appropriate
            //accountDetail with no transaction is 7, start from length 8, display transaction detail
            switch (accoutDetail.Length)
            {
                case 7:
                    Console.WriteLine($"\t\t\b\b\bRecent Transcation: N/A");
                    break;
                case 8:
                    Console.WriteLine($"\t\t\b\b\bRecent Transcation: {accoutDetail[7]}");
                    break;
                case 9:
                    Console.WriteLine($"\t\t\b\b\bRecent Transcation: {accoutDetail[7]}");
                    Console.WriteLine($"\t\t\b\b\bRecent Transcation: {accoutDetail[8]}");
                    break;
                case 10:
                    Console.WriteLine($"\t\t\b\b\bRecent Transcation: {accoutDetail[7]}");
                    Console.WriteLine($"\t\t\b\b\bRecent Transcation: {accoutDetail[8]}");
                    Console.WriteLine($"\t\t\b\b\bRecent Transcation: {accoutDetail[9]}");
                    break;
                case 11:
                    Console.WriteLine($"\t\t\b\b\bRecent Transcation: {accoutDetail[7]}");
                    Console.WriteLine($"\t\t\b\b\bRecent Transcation: {accoutDetail[8]}");
                    Console.WriteLine($"\t\t\b\b\bRecent Transcation: {accoutDetail[9]}");
                    Console.WriteLine($"\t\t\b\b\bRecent Transcation: {accoutDetail[10]}");
                    break;
                default:
                    Console.WriteLine($"\t\t\b\b\bRecent Transcation: {accoutDetail[accoutDetail.Length - 5]}");
                    Console.WriteLine($"\t\t\b\b\bRecent Transcation: {accoutDetail[accoutDetail.Length - 4]}");
                    Console.WriteLine($"\t\t\b\b\bRecent Transcation: {accoutDetail[accoutDetail.Length - 3]}");
                    Console.WriteLine($"\t\t\b\b\bRecent Transcation: {accoutDetail[accoutDetail.Length - 2]}");
                    Console.WriteLine($"\t\t\b\b\bRecent Transcation: {accoutDetail[accoutDetail.Length - 1]}");
                    break;
            }
            Console.WriteLine("\t ------------------------------------------------------------- ");
            Console.WriteLine("");

            //get user input and dertermine whether to send email or not
            string emailState = "";
            while (emailState != "y" && emailState != "n")
            {
                Console.Write("\t\t Email statement (y/n)? ");
                emailState = Console.ReadLine();
            }
            if (emailState == "n")
            {
                this.error = false;
            } else if (emailState == "y")
            {
                //send the email
                EmailBody emailBody = new EmailBody(accoutDetail[2], accoutDetail[3], accoutDetail[4], accoutDetail[6], Convert.ToInt32(accoutDetail[0]), Convert.ToInt32(accoutDetail[5]));
                EmailSender emailSender = new EmailSender();
                emailSender.sendEmail(this.emailSenderAddress, accoutDetail[6], emailBody, Convert.ToDouble(accoutDetail[1]), false);
                Console.WriteLine("\t\t Email sent Successfully!...");
                Console.WriteLine("\t\t Press any key to go to the menu..");
                Console.ReadKey();
            }
        }
    }
}
