using System;
namespace dotNet_ass1
{
    public class ErrorHandler
    {
        public bool CheckUserInput()
        {
            string confirm = "";
            while (confirm != "y" && confirm != "n")
            {
                Console.Write("\t\t Retry (y/n)? ");
                confirm = Console.ReadLine();
            }
            if (confirm == "n")
            {
                return false;
            }
            return true;
        }
    }
}
