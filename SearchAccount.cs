using System;
namespace dotNet_ass1
{
    public class SearchAccount
    {
        private bool error;
        private int accNum;
        private int feedbackLeft, feedbackTop;
        public void SearchAccountScreen()
        {
            do
            {
                try
                {
                    this.error = false;
                    Console.Clear();
                    Console.WriteLine("         ------------------------------------------------------------- ");
                    Console.WriteLine("        |                       Search An Account                     |");
                    Console.WriteLine("         =============================================================");
                    Console.WriteLine("        |                 Enter the Account number below              |");
                    Console.WriteLine("        |                                                             |");
                    Console.Write("        | Account number: ");
                    int numberLeft = Console.CursorLeft;
                    int numberTop = Console.CursorTop;
                    Console.Write("                                             |\n");
                    Console.WriteLine("        |                                                             |");
                    Console.WriteLine("         ------------------------------------------------------------- ");
                    this.feedbackLeft = Console.CursorLeft;
                    this.feedbackTop = Console.CursorTop;
                    Console.SetCursorPosition(numberLeft, numberTop);
                    string userInput = Console.ReadLine();
                    this.accNum = Convert.ToInt32(userInput);
                    if (userInput.Length > 10)
                    {
                        throw new Exception("Invalid account number");
                    }
                    Console.ReadKey();
                }
                catch (Exception e)
                {
                    this.error = true;
                    Console.SetCursorPosition(this.feedbackLeft, this.feedbackTop);
                    Console.WriteLine("                 " + e.Message);
                    Console.WriteLine("                 Press any key to re-enter details..");
                    Console.ReadKey();
                }
            } while (this.error);
        }
    }
}
