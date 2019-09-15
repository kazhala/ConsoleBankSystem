using System;
namespace dotNet_ass1
{
    //Display menu page
    public class Menu
    {
        //Let main program access the userchoice
        public int UserChoice { get; set; }
        public int MenuScreen()
        {
            int resultLeft, resultTop, choiceLeft, choiceTop;

            //set error to false for do while loop to function
            bool error = false;
            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("\t ------------------------------------------------------------- ");
                    Console.WriteLine("\t|                Welcome to KAZ Banking System                |");
                    Console.WriteLine("\t =============================================================");
                    Console.WriteLine("\t|             1. Create a new account                         |");
                    Console.WriteLine("\t|             2. Seach for an account                         |");
                    Console.WriteLine("\t|             3. Deposit                                      |");
                    Console.WriteLine("\t|             4. Withdraw                                     |");
                    Console.WriteLine("\t|             5. A/C statement                                |");
                    Console.WriteLine("\t|             6. Delete account                               |");
                    Console.WriteLine("\t|             7. Exit                                         |");
                    Console.WriteLine("\t ------------------------------------------------------------- ");
                    Console.WriteLine("\t|                                                             |");
                    Console.Write("\t|        Enter your choice (1-7): ");

                    //Record the cursor position
                    choiceLeft = Console.CursorLeft;
                    choiceTop = Console.CursorTop;
                    Console.Write("                            |\n");
                    Console.WriteLine("\t|                                                             |");
                    Console.WriteLine("\t ------------------------------------------------------------- ");
                    resultLeft = Console.CursorLeft;
                    resultTop = Console.CursorTop;

                    //set cursor position to choice
                    Console.SetCursorPosition(choiceLeft, choiceTop);
                    string userInput = Console.ReadLine();
                    Console.SetCursorPosition(resultLeft, resultTop);
                    UserChoice = Convert.ToInt32(userInput);

                    //if user input is not 1-7, throw exception
                    //if user enter text, abover convert would throw error
                    if (UserChoice > 7 || UserChoice < 1)
                    {
                        throw new Exception("Please enter a number between 1-7");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("\t\t " + e.Message);

                    //set error to true so that the loop would execute for user to re-enter
                    error = true;
                    Console.WriteLine("\t\t Press any key to continue...");
                    //Console.ReadKey();
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
