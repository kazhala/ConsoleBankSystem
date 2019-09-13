using System;
using System.IO;
namespace dotNet_ass1
{
    public class Deposit
    {
        private bool error;
        private int accNum, amount;
        private int feedbackLeft, feedbackTop;
        public void DepositScreen()
        {
            do
            {
                try
                {
                    this.error = false;
                    Console.Clear();
                    Console.WriteLine("         ------------------------------------------------------------- ");
                    Console.WriteLine("        |                           Deposit                           |");
                    Console.WriteLine("         =============================================================");
                    Console.WriteLine("        |                   Enter The Details Below                   |");
                    Console.WriteLine("        |                                                             |");
                    Console.Write("        | Account Number: ");
                    int accLeft = Console.CursorLeft;
                    int accTop = Console.CursorTop;
                    Console.Write("                                                          |/n");
                    Console.Write("        | Amount: ");
                    int amountLeft = Console.CursorLeft;
                    int amountTop = Console.CursorTop;
                    Console.Write("                                                     |/n");
                    Console.WriteLine("        |                                                             |");
                    Console.WriteLine("         ------------------------------------------------------------- ");
                    this.feedbackLeft = Console.CursorLeft;
                    this.feedbackTop = Console.CursorTop;
                    Console.SetCursorPosition(accLeft, accTop);
                    string tempInput = Console.ReadLine();
                    this.accNum = Convert.ToInt32(tempInput);
                    Console.SetCursorPosition(amountLeft, amountTop);
                    tempInput = Console.ReadLine();
                    Console.SetCursorPosition(this.feedbackLeft, this.feedbackTop);
                }
                catch (Exception e)
                {
                    this.error = true;
                    Console.SetCursorPosition(this.feedbackLeft, this.feedbackTop);
                    Console.WriteLine("                 " + e.Message);
                    Console.WriteLine("                 Press any key to re-enter..");
                    Console.ReadKey();
                }

            } while (this.error);
        }
    }
}
