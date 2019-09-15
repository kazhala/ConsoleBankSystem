using System;
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
            ErrorHandler errorHandler = new ErrorHandler();
            CheckDBacc checkDBacc = new CheckDBacc();
            do
            {
                try
                {
                    this.error = false;
                    Console.Clear();
                    Console.WriteLine("\t ------------------------------------------------------------- ");
                    Console.WriteLine("\t|                           Withdraw                          |");
                    Console.WriteLine("\t =============================================================");
                    Console.WriteLine("\t|                   Enter The Details Below                   |");
                    Console.WriteLine("\t|                                                             |");
                    Console.Write("\t| Account Number: ");

                    //record cursor position
                    int accLeft = Console.CursorLeft;
                    int accTop = Console.CursorTop;
                    Console.Write("                                            |\n");
                    Console.Write("\t| Amount: $");
                    int amountLeft = Console.CursorLeft;
                    int amountTop = Console.CursorTop;
                    Console.Write("                                                   |\n");
                    Console.WriteLine("\t|                                                             |");
                    Console.WriteLine("\t ------------------------------------------------------------- ");
                    this.feedbackLeft = Console.CursorLeft;
                    this.feedbackTop = Console.CursorTop;

                    //set cursor position
                    Console.SetCursorPosition(accLeft, accTop);
                    string tempInput = Console.ReadLine();
                    this.accNum = Convert.ToInt32(tempInput);

                    //check if user input is less than 10 digit
                    //check for 0 because 0 is used as placeholders in accDB
                    if (tempInput.Length > 10 || this.accNum == 0)
                    {
                        throw new Exception("Invalid account number");
                    }

                    Console.SetCursorPosition(this.feedbackLeft, this.feedbackTop);

                    //check if user account exist in accDB
                    if (!checkDBacc.checkExist(this.accNum))
                    {
                        throw new Exception("Account number invalid");
                    }
                    else if (checkDBacc.checkExist(this.accNum))
                    {
                        Console.WriteLine("\t\t Account found! Enter the amount...");
                        this.feedbackLeft = Console.CursorLeft;
                        this.feedbackTop = Console.CursorTop;

                        //set cursor back to amount
                        Console.SetCursorPosition(amountLeft, amountTop);
                        tempInput = Console.ReadLine();

                        //round the input to 2 decimal
                        this.amount = Math.Round(Convert.ToDouble(tempInput), 2);
                        withDrawFromDB(this.accNum, this.amount);
                        Console.SetCursorPosition(this.feedbackLeft, this.feedbackTop);
                        Console.WriteLine("\t\t Withdraw successful");
                        Console.WriteLine("\t\t Press any key to go to menu..");
                    }

                    Console.ReadKey();
                }
                catch (Exception e)
                {
                    Console.SetCursorPosition(this.feedbackLeft, this.feedbackTop);
                    Console.WriteLine("\t\t " + e.Message);
                    //check userinput if its y or n, and set error accordingl
                    this.error = errorHandler.CheckUserInput();
                    
                }

            } while (this.error);
        }
        

        private void withDrawFromDB(int acc, double amt)
        {
            //get all account detail from file to array
            string[] accountDetail = File.ReadAllLines($"{acc}.txt");
            double prevAmt = Convert.ToDouble(accountDetail[1]);

            //check if the amount is sufficient
            if(prevAmt < amt)
            {
                throw new Exception("Insufficient balance");
            }

            //check if input is valid
            if (amt < 0)
            {
                throw new Exception("Cannot with draw negative amount");
            }
            double newAmt = prevAmt - amt;
            accountDetail[1] = Convert.ToString(newAmt);

            //re write all the information back to the file
            File.WriteAllText($"{acc}.txt", accountDetail[0]);
            for (int lineNum = 1; lineNum < accountDetail.Length; ++lineNum)
            {
                File.AppendAllText($"{acc}.txt", $"\n{accountDetail[lineNum]}");
            }

            //record the transaction detail at the end of the file
            File.AppendAllText($"{acc}.txt", $"\nWithdraw: {Convert.ToString(amt)}");
        }
    }
}
