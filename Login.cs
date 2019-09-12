using System;
using System.IO;

namespace dotNet_ass1
{
    class Login
    {
        private string userName, passWord;
        private bool loginSuccess = false;
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
        public void LoginScreen()
        {
            Console.Clear();
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
            int resultLeft = Console.CursorLeft;
            int resultTop = Console.CursorTop;
            Console.SetCursorPosition(usernameLeft, usernameTop);
            this.userName = Console.ReadLine();
            Console.SetCursorPosition(passwordLeft, passwordTop);
            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                // Backspace Should Not Work
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    this.passWord += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && this.passWord.Length > 0)
                    {
                        this.passWord = this.passWord.Substring(0, (this.passWord.Length - 1));
                        Console.Write("\b \b");
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
            } while (true);
            Console.SetCursorPosition(resultLeft, resultTop);
            string[] loginDetail = File.ReadAllLines("login.txt");
            foreach (string line in loginDetail)
            {
                string[] namepass = line.Split('|');
                if (this.userName == namepass[0])
                {
                    if (this.passWord == namepass[1])
                    {
                        this.loginSuccess = true;
             
                    }
                }
            
            }
            if (!this.loginSuccess)
            {
                Console.Write("        Credential invalid, please re-enter your detail!");
            }else if(this.loginSuccess){
                Console.Write("        Valid credentials, press any key to continue!");
            }
            Console.ReadKey();
        }
    }
}
