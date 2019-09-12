using System;
using System.IO;

namespace dotNet_ass1
{
    class Login
    {
        private string userName, passWord;
        private bool loginSuccess = false;
        private bool exit = false;
        public string Name
        {
            get
            {
                return this.userName;
            }
        }
        public bool LoginSuccess
        {
            get
            {
                return this.loginSuccess;
            }
        }
        public bool Exit
        {
            get
            {
                return this.exit;
            }
        }
        public void LoginScreen()
        {
            Console.WriteLine("         ------------------------------------------------------------- ");
            Console.WriteLine("        |                Welcome to KAZ Banking System                |");
            Console.WriteLine("         =============================================================");
            Console.WriteLine("        |                        Please Login                         |");
            Console.WriteLine("        |                                                             |");
            Console.Write("        | User name: ");
            int usernameLeft = Console.CursorLeft;
            int usernameTop = Console.CursorTop;
            Console.Write("                                                 |\n");
            Console.Write("        | Password: ");
            int passwordLeft = Console.CursorLeft;
            int passwordTop = Console.CursorTop;
            Console.Write("                                                  |\n");
            Console.WriteLine("        |                                                             |");
            Console.WriteLine("         ------------------------------------------------------------- ");
            Console.ReadKey();
        }
    }
}
