using System;
using System.IO;

namespace dotNet_ass1
{
    public class Deposit
    {
        private bool error;
        private int accNum;
        private double amount;
        private int feedbackLeft, feedbackTop;
        public void DepositScreen()
        {
            ErrorHandler errorHandler = new ErrorHandler();
            CheckDBacc checkDBacc = new CheckDBacc();


            //do while loop if user want to re-enter
            do
            {
                try
                {
                    this.error = false;
                    Console.Clear();
                    Console.WriteLine("\t ------------------------------------------------------------- ");
                    Console.WriteLine("\t|                           Deposit                           |");
                    Console.WriteLine("\t =============================================================");
                    Console.WriteLine("\t|                   Enter The Details Below                   |");
                    Console.WriteLine("\t|                                                             |");
                    Console.Write("\t| Account Number: ");

                    //record the current cursor position
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

                    //check if input is within 10 digit
                    //check for 0 because accDB use 0 as placeholders
                    if (tempInput.Length > 10 || this.accNum == 0)
                    {
                        throw new Exception("Invalid account number");
                    }
                    
                    Console.SetCursorPosition(this.feedbackLeft, this.feedbackTop);
                    if (!checkDBacc.checkExist(this.accNum))
                    {
                        throw new Exception("Account number invalid");
                    }
                    else if (checkDBacc.checkExist(this.accNum))
                    {
                        Console.WriteLine("\t\t Account found! Enter the amount...");
                        this.feedbackLeft = Console.CursorLeft;
                        this.feedbackTop = Console.CursorTop;
                        Console.SetCursorPosition(amountLeft, amountTop);
                        tempInput = Console.ReadLine();

                        //Convert the user input to 2 decimal
                        this.amount = Math.Round(Convert.ToDouble(tempInput),2);

                        //change the amount in file
                        depostToDB(this.accNum, this.amount);
                        Console.SetCursorPosition(this.feedbackLeft, this.feedbackTop);
                        Console.WriteLine("\t\t Deposit successful");
                        Console.WriteLine("\t\t Press any key to go to menu..");
                    }

                    Console.ReadKey();
                }
                catch (Exception e)
                {
                    Console.SetCursorPosition(this.feedbackLeft, this.feedbackTop);
                    Console.WriteLine("\t\t " + e.Message);
                    //based on user input, set error to true or false
                    this.error = errorHandler.CheckUserInput();
                }

            } while (this.error);
        }
        
        //handle update file amout
        private void depostToDB(int acc, double amt)
        {
            //get all details from the file
            string[] accountDetail = File.ReadAllLines($"{acc}.txt");
            double prevAmt = Convert.ToDouble(accountDetail[1]);
            double newAmt = prevAmt + amt;

            //update the field for amount
            accountDetail[1] = Convert.ToString(newAmt);

            //re write all the information back to the file
            File.WriteAllText($"{acc}.txt", accountDetail[0]);
            for (int lineNum = 1; lineNum < accountDetail.Length; ++lineNum)
            {
                File.AppendAllText($"{acc}.txt", $"\n{accountDetail[lineNum]}");
            }

            //Record the transaction at the bottom of the file
            File.AppendAllText($"{acc}.txt", $"\nDeposit: {Convert.ToString(amt)}");
        }
    }
}
