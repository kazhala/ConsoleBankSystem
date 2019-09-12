using System;
namespace dotNet_ass1
{
    public class Menu
    {
        public int UserChoice { get; set; }
        public int MenuScreen()
        {
            int resultLeft, resultTop, choiceLeft, choiceTop;
            bool error = false;
            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("         ------------------------------------------------------------- ");
                    Console.WriteLine("        |                Welcome to KAZ Banking System                |");
                    Console.WriteLine("         =============================================================");
                    Console.WriteLine("        |             1. Create a new account                         |");
                    Console.WriteLine("        |             2. Seach for an account                         |");
                    Console.WriteLine("        |             3. Deposit                                      |");
                    Console.WriteLine("        |             4. Withdraw                                     |");
                    Console.WriteLine("        |             5. A/C statement                                |");
                    Console.WriteLine("        |             6. Delete account                               |");
                    Console.WriteLine("        |             7. Exit                                         |");
                    Console.WriteLine("         ------------------------------------------------------------- ");
                    Console.WriteLine("        |                                                             |");
                    Console.Write("        |        Enter your choice (1-7): ");
                    choiceLeft = Console.CursorLeft;
                    choiceTop = Console.CursorTop;
                    Console.Write("                            |\n");
                    Console.WriteLine("        |                                                             |");
                    Console.WriteLine("         ------------------------------------------------------------- ");
                    resultLeft = Console.CursorLeft;
                    resultTop = Console.CursorTop;
                    Console.SetCursorPosition(choiceLeft, choiceTop);
                    string userInput = Console.ReadLine();
                    Console.SetCursorPosition(resultLeft, resultTop);
                    UserChoice = Convert.ToInt32(userInput);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    error = true;
                    Console.ReadKey();
                }
                finally
                {
                    if (UserChoice >= 1 && UserChoice <= 7)
                    {
                        error = false;
                    }
                }
            } while (error);
            return UserChoice;
        }
    }
}
