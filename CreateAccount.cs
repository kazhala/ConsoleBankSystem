using System;
namespace dotNet_ass1
{
    public class CreateAccount
    {
        private bool error = false;
        private string firstName, lastName, userAddress, emailAdd;
        private int phoneNum;
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
                    Console.WriteLine("        |                     Enter the Field Below                   |");
                    Console.WriteLine("        |                                                             |");
                    Console.Write("        | First Name: ");
                    int firstNameLeft = Console.CursorLeft;
                    int firstNameTop = Console.CursorTop;
                    Console.Write("                                                |\n");
                    Console.Write("        | Last Name: ");
                    int lastNameLeft = Console.CursorLeft;
                    int lastNameTop = Console.CursorTop;
                    Console.Write("                                                 |\n");
                    Console.Write("        | Address: ");
                    int addressLeft = Console.CursorLeft;
                    int addressTop = Console.CursorTop;
                    Console.Write("                                                   |\n");
                    Console.Write("        | Phone: ");
                    int phoneLeft = Console.CursorLeft;
                    int phoneTop = Console.CursorTop;
                    Console.Write("                                                     |\n");
                    Console.Write("        | Email: ");
                    int emailLeft = Console.CursorLeft;
                    int emailTop = Console.CursorTop;
                    Console.Write("                                                     |\n");
                    Console.WriteLine("        |                                                             |");
                    Console.WriteLine("         ------------------------------------------------------------- ");
                    int feedbackLeft = Console.CursorLeft;
                    int feedbackTop = Console.CursorTop;
                    Console.SetCursorPosition(firstNameLeft, firstNameTop);
                    this.firstName = Console.ReadLine();
                    Console.SetCursorPosition(lastNameLeft, lastNameTop);
                    this.lastName = Console.ReadLine();
                    Console.SetCursorPosition(addressLeft, addressTop);
                    this.userAddress = Console.ReadLine();
                    Console.SetCursorPosition(phoneLeft, phoneTop);
                    string tempInput = Console.ReadLine();
                    phoneNum = Convert.ToInt32(tempInput);
                    Console.SetCursorPosition(emailLeft, emailTop);
                    emailAdd = Console.ReadLine();
                    


                    Console.ReadKey();


                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Press any key to re-enter details");
                    Console.ReadKey();
                }
            } while (error);
        }
    }
}
