using System;
namespace dotNet_ass1
{
    public class CreateAccount
    {
        private bool error = false;
        public void NewAccScreen()
        {
            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("         ------------------------------------------------------------- ");
                    Console.WriteLine("        |                      Create A New Account                   |");
                    Console.WriteLine("         =============================================================");
                    Console.WriteLine("        |                      Enter the Field Below                  |");
                    Console.WriteLine("        |                                                             |");
                    Console.Write("        | First Name: ");
                    int firstNameLeft = Console.CursorLeft;
                    int firstNameTop = Console.CursorTop;
                    Console.Write("                                                |\n");
                    Console.Write("        | Last Name: ");
                    int lastNameLeft = Console.CursorLeft;
                    int lastNameTop = Console.CursorTop;
                    Console.Write("                                                |\n");
                    Console.Write("        | Address: ");
                    int addressLeft = Console.CursorLeft;
                    int addressTop = Console.CursorTop;
                    Console.Write("                                             |\n");
                    Console.Write("        | Phone: ");
                    int phoneLeft = Console.CursorLeft;
                    int phoneTop = Console.CursorTop;
                    Console.Write("                                           |\n");
                    Console.Write("        | Email: ");
                    int emailLeft = Console.CursorLeft;
                    int emailTop = Console.CursorTop;
                    Console.Write("                                           |\n");
                    Console.WriteLine("         ------------------------------------------------------------- ");
                    int feedbackLeft = Console.CursorLeft;
                    int feedbackTop = Console.CursorTop;




                }
                catch (Exception e)
                {

                }
            } while (error);
        }
    }
}
