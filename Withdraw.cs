﻿using System;
using System.IO;
namespace dotNet_ass1
{
    public class Withdraw
    {
        private bool error;
        private int accNum;
        private double amount;
        private int feedbackLeft, feedbackTop;
        public void WithdrawScreen()
        {
            do
            {
                try
                {
                    this.error = false;
                    Console.Clear();
                    Console.WriteLine("         ------------------------------------------------------------- ");
                    Console.WriteLine("        |                           Withdraw                          |");
                    Console.WriteLine("         =============================================================");
                    Console.WriteLine("        |                   Enter The Details Below                   |");
                    Console.WriteLine("        |                                                             |");
                    Console.Write("        | Account Number: ");
                    int accLeft = Console.CursorLeft;
                    int accTop = Console.CursorTop;
                    Console.Write("                                            |\n");
                    Console.Write("        | Amount: $");
                    int amountLeft = Console.CursorLeft;
                    int amountTop = Console.CursorTop;
                    Console.Write("                                                   |\n");
                    Console.WriteLine("        |                                                             |");
                    Console.WriteLine("         ------------------------------------------------------------- ");
                    this.feedbackLeft = Console.CursorLeft;
                    this.feedbackTop = Console.CursorTop;
                    Console.SetCursorPosition(accLeft, accTop);
                    string tempInput = Console.ReadLine();
                    this.accNum = Convert.ToInt32(tempInput);

                    Console.SetCursorPosition(this.feedbackLeft, this.feedbackTop);
                    if (!checkExist(this.accNum))
                    {
                        throw new Exception("Account number invalid");
                    }
                    else if (checkExist(this.accNum))
                    {
                        Console.WriteLine("                 Account found! Enter the amount...");
                        this.feedbackLeft = Console.CursorLeft;
                        this.feedbackTop = Console.CursorTop;
                        Console.SetCursorPosition(amountLeft, amountTop);
                        tempInput = Console.ReadLine();
                        this.amount = Convert.ToDouble(tempInput);
                        withDrawFromDB(this.accNum, this.amount);
                        Console.SetCursorPosition(this.feedbackLeft, this.feedbackTop);
                        Console.WriteLine("                 Withdraw successful");
                        Console.WriteLine("                 Press any key to go to menu..");
                    }

                    Console.ReadKey();
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

        private void withDrawFromDB(int acc, double amt)
        {
            string[] accountDetail = File.ReadAllLines($"{acc}.txt");
            double prevAmt = Convert.ToDouble(accountDetail[1]);
            if(prevAmt < amt)
            {
                throw new Exception("Insufficient balance");
            }
            if (amt < 0)
            {
                throw new Exception("Cannot with draw negative amount");
            }
            double newAmt = prevAmt - amt;
            accountDetail[1] = Convert.ToString(newAmt);
            File.WriteAllText($"{acc}.txt", accountDetail[0]);
            for (int lineNum = 1; lineNum < accountDetail.Length; ++lineNum)
            {
                File.AppendAllText($"{acc}.txt", $"\n{accountDetail[lineNum]}");
            }
            File.AppendAllText($"{acc}.txt", $"\nWithdraw: {Convert.ToString(amt)}");
        }
    }
}
