using System;
using System.IO;
namespace dotNet_ass1
{
    //display the search account screen
    public class SearchAccount
    {
        private bool error;
        private int accNum;
        private int feedbackLeft, feedbackTop;
        private string confirm;
        public void SearchAccountScreen()
        {
            CheckDBacc checkDBacc = new CheckDBacc();

            //do while loop to keep display the screen incase user want to re enter
            do
            {
                try
                {
                    this.error = false;
                    Console.Clear();
                    Console.WriteLine("\t ------------------------------------------------------------- ");
                    Console.WriteLine("\t|                       Search An Account                     |");
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

                    //set cursor posiition to account number position
                    Console.SetCursorPosition(numberLeft, numberTop);
                    
                    string tempInput = Console.ReadLine();
                    this.accNum = Convert.ToInt32(tempInput);

                    //check if account entered is within 10 digits
                    //check if enter = 0 because in accDB, after account deletion, 0 would be placeholder
                    if (tempInput.Length > 10 || this.accNum == 0)
                    {
                        throw new Exception("Account number invalid");
                    }
                    Console.SetCursorPosition(this.feedbackLeft, this.feedbackTop);

                    //check if acc number is in the accDB.txt
                    if (!checkDBacc.checkExist(this.accNum))
                    {
                        Console.WriteLine("\t\t Account not found");
                    } else if (checkDBacc.checkExist(this.accNum))
                    {
                        //display the account detail
                        displayFound(this.accNum);
                        this.feedbackLeft = Console.CursorLeft;
                        this.feedbackTop = Console.CursorTop;
                    }

                    //let user decide if want to continue
                    throw new Exception("");
                  
                }
                catch (Exception e)
                {
                    //set error to true to continue looping
                    this.error = true;
                    Console.SetCursorPosition(this.feedbackLeft, this.feedbackTop);
                    Console.WriteLine("\t\t " + e.Message);
                    this.confirm = "";
                    while (this.confirm != "y" && this.confirm != "n")
                    {
                        Console.Write("\t\t Check another account (y/n)? ");
                        this.confirm = Console.ReadLine();
                    }
                    if (this.confirm == "n")
                    {
                        //if no, then stop loop
                        this.error = false;
                    }
                }
            } while (this.error);
        }

        

        //used to display the account detail
        private void displayFound(int accnumber)
        {
            DisplayDetail displayDetail = new DisplayDetail();
            //store user detail to array
            string[] accoutDetail = File.ReadAllLines($"{accnumber}.txt");
            Console.WriteLine("\t ------------------------------------------------------------- ");
            Console.WriteLine("\t|                        Account Details                      |");
            Console.WriteLine("\t =============================================================");
            Console.WriteLine("");
            displayDetail.UserDetails(accoutDetail);
            Console.WriteLine("\t ------------------------------------------------------------- ");
        }
    }
}
