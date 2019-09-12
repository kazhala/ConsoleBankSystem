using System;
namespace dotNet_ass1
{
    public class Menu
    {
        public int MenuScreen()
        {
            int n = 0;
            Console.Clear();
            Console.WriteLine("         ------------------------------------------------------------- ");
            Console.WriteLine("        |                Welcome to KAZ Banking System                |");
            Console.WriteLine("         =============================================================");
            Console.WriteLine("        |            1. Create a new account                          |");
            Console.WriteLine("        |            2. Seach for an account                          |");
            Console.WriteLine("        |            3. Deposit                                       |");
            Console.WriteLine("        |            4. Withdraw                                      |");
            Console.WriteLine("        |            5. A/C statement                                 |");
            Console.WriteLine("        |            6. Delete account                                |");
            Console.WriteLine("        |            7. Exit                                          |");



            return n;
        }
    }
}
