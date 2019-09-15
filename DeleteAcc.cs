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
            ErrorHandler errorHandler = new ErrorHandler();
            CheckDBacc checkDBacc = new CheckDBacc();
            //do while loop if user wants to re-enter
            do
            {
                try
                {
                    this.error = false;
                    Console.Clear();
                    Console.WriteLine("\t ------------------------------------------------------------- ");
                    Console.WriteLine("\t|                       Delete an Account                     |");
                    Console.WriteLine("\t =============================================================");
                    Console.WriteLine("\t|                 Enter the Account number below              |");
                    Console.WriteLine("\t|                                                             |");
                    Console.Write("\t| Account number: ");
                    //record the current cursor position
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
                    this.accNum = Convert.ToInt32(tempInput);

                    //check user input if greater than 10 digit
                    //check for 0 because accDB use 0 as placeholders
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
                        Console.WriteLine("\t\t Account found, Details are displayed below.");
                        Console.WriteLine("");
                        //display account detail
                        //inside diplayFound would call delete file function
                        DisplayFound(this.accNum);
                        
                    }
                }
                catch (OverflowException ex)
                {
                    ex.ToString();
                    Console.SetCursorPosition(this.feedbackLeft, this.feedbackTop);
                    Console.WriteLine("\t\t Account number is too long");
                    this.error = errorHandler.CheckUserInput();
                }

                catch (Exception e)
                {
                    Console.SetCursorPosition(this.feedbackLeft, this.feedbackTop);
                    Console.WriteLine("\t\t " + e.Message);
                    this.error = errorHandler.CheckUserInput();
                }

            } while (this.error);
        }
        
        private void DisplayFound(int accnumber)
        {
            DisplayDetail displayDetail = new DisplayDetail();

            //store all the detail into array
            string[] accoutDetail = File.ReadAllLines($"{accnumber}.txt");
            Console.WriteLine("\t ------------------------------------------------------------- ");
            Console.WriteLine("\t|                        Account Details                      |");
            Console.WriteLine("\t =============================================================");
            Console.WriteLine("");
            //display user detail
            displayDetail.UserDetails(accoutDetail);
            Console.WriteLine("\t ------------------------------------------------------------- ");

            //check if user wants to delete
            string deleteInput = "";
            while (deleteInput != "y" && deleteInput != "n")
            {
                Console.Write("\t\t Delete (y/n)? ");
                deleteInput = Console.ReadLine();
            }
            if (deleteInput == "n")
            {
                this.error = false;
            }
            else if (deleteInput == "y")
            {
                //delete the account file and account number in the accDB
                DeleteAction(accnumber);
            }
        }

        //delete file + account num in accDB
        private void DeleteAction(int accnumber)
        {
            //store all acc into array
            string[] allAccount = File.ReadAllLines("accDB.txt");

            //create arrayList for easier array operation
            ArrayList updatedAllAccount = new ArrayList();

            //add all details into arraylist
            foreach (string account in allAccount)
            {
                updatedAllAccount.Add(account);
            }

            //remove the provided account number from the account list
            updatedAllAccount.Remove(Convert.ToString(accnumber));

            //place a 0 as placeholder for not causing duplicate number when generating new acc num
            updatedAllAccount.Add("0");

            //Clear the file and rewrite the first number into accDB.txt
            File.WriteAllText("accDB.txt", Convert.ToString(updatedAllAccount[0]));

            //remove the first number from arraylist, then add all data from list to the file
            updatedAllAccount.RemoveAt(0);
            foreach (string account in updatedAllAccount)
            {
                File.AppendAllText("accDB.txt", "\n"+Convert.ToString(account));
            }

            //remove the file
            File.Delete($"{accnumber}.txt");
            Console.WriteLine("");
            Console.WriteLine("\t\t Account deleted..");
            Console.ReadKey();
        }
    }
}
