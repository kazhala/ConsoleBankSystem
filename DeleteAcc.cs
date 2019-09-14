using System;
using System.IO;
using System.Collections;
namespace dotNet_ass1
{
    public class DeleteAcc
    {
        private bool error;
        private int accNum;
        private int feedbackLeft, feedbackTop;
        public void DeleteScreen()
        {
            do
            {
                try
                {
                    this.error = false;
                    Console.Clear();
                    Console.WriteLine("         ------------------------------------------------------------- ");
                    Console.WriteLine("        |                       Delete an Account                     |");
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
                    if (tempInput.Length > 10)
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
                        Console.WriteLine("                 Account found, Details are displayed below.");
                        Console.WriteLine("");
                        displayFound(this.accNum);
                        Console.ReadKey();
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
            Console.WriteLine("         ------------------------------------------------------------- ");
            string deleteInput = "";
            while (deleteInput != "y" && deleteInput != "n")
            {
                Console.Write("                  Delete (y/n)? ");
                deleteInput = Console.ReadLine();
            }
            if (deleteInput == "n")
            {
                this.error = false;
            }
            else if (deleteInput == "y")
            {
                deleteAction(accnumber);
            }
        }
        private void deleteAction(int accnumber)
        {
            string[] allAccount = File.ReadAllLines("accDB.txt");
            ArrayList updatedAllAccount = new ArrayList();
            foreach (string account in allAccount)
            {
                Console.WriteLine(account);
                updatedAllAccount.Add(account);
            }
            updatedAllAccount.Remove(Convert.ToString(accnumber));
            foreach (string account in updatedAllAccount)
            {
                Console.WriteLine(account);
            }
            
        }
    }
}
