﻿using System;
using System.IO;
namespace dotNet_ass1
{
    //display statement
    public class Statement
    {
        private bool error;
        private int accNum;
        private int feedbackLeft, feedbackTop;
        private string emailSenderAddress = "xuzhuang9897@gmail.com";
        public void StatementScreen()
        {
            ErrorHandler errorHandler = new ErrorHandler();
            CheckDBacc checkDBacc = new CheckDBacc();
            DisplayDetail displayDetail = new DisplayDetail();
            do
            {
                try
                {
                    this.error = false;
                    Console.Clear();
                    Console.WriteLine("         ------------------------------------------------------------- ");
                    Console.WriteLine("        |                           Statement                         |");
                    Console.WriteLine("         =============================================================");
                    Console.WriteLine("        |                 Enter the Account number below              |");
                    Console.WriteLine("        |                                                             |");
                    Console.Write("        | Account number: ");
                    int numberLeft = Console.CursorLeft;
                    int numberTop = Console.CursorTop;
                    Console.Write("                                            |\n");
                    Console.WriteLine("        |                                                             |");
                    Console.WriteLine("         ------------------------------------------------------------- ");
                    this.feedbackLeft = Console.CursorLeft;
                    this.feedbackTop = Console.CursorTop;
                    Console.SetCursorPosition(numberLeft, numberTop);

                    string tempInput = Console.ReadLine();
                    //Console.WriteLine(tempInput);
                    this.accNum = Convert.ToInt32(tempInput);
                    if (tempInput.Length > 10 || this.accNum == 0)
                    {
                        throw new Exception("Invalid account number");
                    }
                    Console.SetCursorPosition(this.feedbackLeft, this.feedbackTop);
                    if (!checkExist(this.accNum))
                    {
                        throw new Exception("Account not found");
                    }
                    else if (checkExist(this.accNum))
                    {
                        Console.WriteLine("                 Account found, statement is displayed below.");
                        Console.WriteLine("");
                        displayFound(this.accNum);
                    }

                    
                }
                catch (Exception e)
                {
                    this.error = true;
                    Console.SetCursorPosition(this.feedbackLeft, this.feedbackTop);
                    Console.WriteLine("                 " + e.Message);
                    string confirm = "";
                    while (confirm != "y" && confirm != "n")
                    {
                        Console.Write("                 Retry (y/n)? ");
                        confirm = Console.ReadLine();
                    }
                    if (confirm == "n")
                    {
                        this.error = false;
                    }
                    
                }
            } while (this.error);
        }
        private bool checkExist(int accnumber)
        {
            //FileStream accDB = new FileStream("accDB.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            string[] allAcc = File.ReadAllLines("accDB.txt");
            foreach (string line in allAcc)
            {

                if (Convert.ToInt32(line) == accnumber)
                {
                    return true;
                }
            }
            return false;
        }
        private void displayFound(int accnumber)
        {
            string[] accoutDetail = File.ReadAllLines($"{accnumber}.txt");
            Console.WriteLine("         ------------------------------------------------------------- ");
            Console.WriteLine("        |                        Account Details                      |");
            Console.WriteLine("         =============================================================");
            Console.WriteLine("                                                                       ");
            Console.WriteLine($"          Account No: {accoutDetail[0]}                               ");
            Console.WriteLine($"          Account Balance: ${accoutDetail[1]}                          ");
            Console.WriteLine($"          First Name: {accoutDetail[2]}                               ");
            Console.WriteLine($"          Last Name: {accoutDetail[3]}                                ");
            Console.WriteLine($"          Address: {accoutDetail[4]}                                  ");
            Console.WriteLine($"          Phone: {accoutDetail[5]}                                    ");
            Console.WriteLine($"          Email: {accoutDetail[6]}                                    ");
            switch (accoutDetail.Length)
            {
                case 7:
                    Console.WriteLine($"          Recent Transcation: N/A");
                    break;
                case 8:
                    Console.WriteLine($"          Recent Transcation: {accoutDetail[7]}");
                    break;
                case 9:
                    Console.WriteLine($"          Recent Transcation: {accoutDetail[7]}");
                    Console.WriteLine($"          Recent Transcation: {accoutDetail[8]}");
                    break;
                case 10:
                    Console.WriteLine($"          Recent Transcation: {accoutDetail[7]}");
                    Console.WriteLine($"          Recent Transcation: {accoutDetail[8]}");
                    Console.WriteLine($"          Recent Transcation: {accoutDetail[9]}");
                    break;
                case 11:
                    Console.WriteLine($"          Recent Transcation: {accoutDetail[7]}");
                    Console.WriteLine($"          Recent Transcation: {accoutDetail[8]}");
                    Console.WriteLine($"          Recent Transcation: {accoutDetail[9]}");
                    Console.WriteLine($"          Recent Transcation: {accoutDetail[10]}");
                    break;
                default:
                    Console.WriteLine($"          Recent Transcation: {accoutDetail[accoutDetail.Length - 5]}");
                    Console.WriteLine($"          Recent Transcation: {accoutDetail[accoutDetail.Length - 4]}");
                    Console.WriteLine($"          Recent Transcation: {accoutDetail[accoutDetail.Length - 3]}");
                    Console.WriteLine($"          Recent Transcation: {accoutDetail[accoutDetail.Length - 2]}");
                    Console.WriteLine($"          Recent Transcation: {accoutDetail[accoutDetail.Length - 1]}");
                    break;
            }
            Console.WriteLine("         ------------------------------------------------------------- ");
            Console.WriteLine("");
            string emailState = "";
            while (emailState != "y" && emailState != "n")
            {
                Console.Write("                  Email statement (y/n)? ");
                emailState = Console.ReadLine();
            }
            if (emailState == "n")
            {
                this.error = false;
            } else if (emailState == "y")
            {
                EmailBody emailBody = new EmailBody(accoutDetail[2], accoutDetail[3], accoutDetail[4], accoutDetail[6], Convert.ToInt32(accoutDetail[0]), Convert.ToInt32(accoutDetail[5]));
                EmailSender emailSender = new EmailSender();
                emailSender.sendEmail(this.emailSenderAddress, accoutDetail[6], emailBody, Convert.ToDouble(accoutDetail[1]), false);
                Console.WriteLine("                  Email sent Successfully!...");
                Console.WriteLine("                  Press any key to go to the menu..");
                Console.ReadKey();
            }
        }
    }
}
